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
             Hej! Jag har kommit på ett flertal lösningar vad gäller själva uppgiften i sig. Jag kör på serialization då jag gillar att "teleportera" data från ett ställe till ett annat. 
             Jag försöker göra det så enkelt och effektivt som möjligt. Skall lägga till tester som testar varje moment av processen av data från konsol app till webben.
             Tänkte fråga er om det hade varit värt att göra det så realtidsmässigt som möjligt. Men jag kör på det ändå då jag vill visa framfötterna!
            */

            Console.Title = "Arbetsprov - Atea";
            HandleMessages hm = new HandleMessages();
            Console.WriteLine("*** Welcome to the console to website application, made by Jean Kam.");
            Console.WriteLine();
            Console.Write(" How it works:\n 1) Write a message \n 2) Press enter \n 3) Enjoy the list of messages on the website!\n");

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
