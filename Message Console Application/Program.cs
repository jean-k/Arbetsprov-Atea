using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Message_Console_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Hej! Jag har kommit på ett flertal lösningar vad gäller själva uppgiften i sig. Jag har kommit fram till att jag skall använda mig av serialization för att kunna
             * visa senaste meddelande som mottagist av hemsidan. Därefter skapa en realtids sida som uppdaterar senaste meddelande samt databasen utan att hela sidan laddas om
             * detta för att skapa en realtidskänsla samt att det känns mer futuristiskt. Jag lägger fokus på att skriva effektiv och och robust kod
           
             * Rent kodmässigt så är det mycket bättre att ha mindre kodsnuttar i varje funktion för att göra det testvänligt, läsvänligt samt gör en komplex kodstruktur lättare att följa.
             * Prestandamässigt sätt så har jag studerat fram till att det är bäst att serializera så lite data som möjligt.
             * Dessutom är det vackrare användarvänlighet med realtids uppdatering av data. Det går att optimera databasdatan ännu mer genom att hämta bara ett antal data från databasen per realtidsuppdatering istället för hela databasen, ifall det skulle finnas 10 000 meddelanden så att säga.
             * Rent testmässigt så har jag gjort en klass HandleMessages med en enda stor funktion. Det krävs en komplex test för att få allt ihop. Jag är inte duktig direkt på att skriva tester och det hade tagit längre tid för att göra test på denna funktion då det krävs databasmocks och serializerings test inkluderat.
             * */

            //Själva menyn som kommer visas högst upp på konsoll appen
            Console.Title = "Arbetsprov - Atea";
            HandleMessages hm = new HandleMessages();
            Console.WriteLine("*** Welcome to the console to website application, made by Jean Kam.");
            Console.WriteLine();
            Console.Write(" How it works:\n 1) Write a message \n 2) Press enter \n 3) Enjoy the incoming messages on the website!\n");

            Console.WriteLine(" To exit this application please write 'e' and press enter.");
            Console.WriteLine("\n");
            Console.WriteLine(" Please write a message below.");

            //While loopen i infinity mode, dvs man kan skicka oändligt med meddelanden tills man skriver 'e' för att avsluta
            while (true)
            {
                Console.WriteLine(" Write a message below!");
                string message = Console.ReadLine();
                //Programmet avslutas när man skriver 'e' och trycker på Enter.
                if (message == "e")
                {
                    break;
                }
                //Programmet tillåter inte tomma meddelanden
                if (message == string.Empty)
                {
                    Console.WriteLine(" You can't write an empty message!");
                    return;
                }
                hm.SaveMessage(message);                
            }
        }
    }
}
