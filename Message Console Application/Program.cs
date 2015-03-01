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
            */

            //Själva menyn som kommer visas högst upp på konsoll appen
            Console.Title = "Arbetsprov - Atea";
            HandleMessages hm = new HandleMessages();
            Console.WriteLine("*** Welcome to the console to website application, made by Jean Kam.");
            Console.WriteLine();
            Console.Write(" How it works:\n 1) Write a message \n 2) Press enter \n 3) Enjoy the incoming messages on the website!\n");

            Console.WriteLine(" To exit this application please write 'e' and press enter.");
            Console.WriteLine("\n");
            Console.WriteLine(" Please write a message below.");

            while (true)
            {
                Console.WriteLine(" Write a message below!");
                string message = Console.ReadLine();
                if (message == "e")
                {
                    break;
                }
                if (message == string.Empty)
                {
                    Console.WriteLine(" You can't write an empty message!");
                }
                hm.SaveMessage(message);                
            }
        }
    }
}
