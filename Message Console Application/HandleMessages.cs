using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Message_Console_Application
{
    [Serializable]
    public class HandleMessages
    {
        //skapa filvägen på webprojektet för att serializera senast inkomna meddelande som skall användas på hemsidan
        public void SaveMessage(string message)
        {
            //Om meddelandet innehåller data så ska följande hända:
            if (message != null)
            {
                //Gör om strängen och går in i en annan mapp för att nå xml filen
                string path = Environment.CurrentDirectory;
                string filePath = Path.Combine(path.Substring(0, (path.Length - 37)), "MessageReceiver_Webapp\\MessageData\\MessageData.xml");
                /* Den här funktionen gör två saker, för det första serializeras ett meddelande till webbprojektet 
                och för det andra så läggs meddelandet till i databasen som ligger på webbprojektet  */
                try
                {
                    FileStream fs = new FileStream(filePath, FileMode.Create);                                          
                    try
                    {
                        LinqConsoleToDBDataContext dbContext = new LinqConsoleToDBDataContext();
                        XmlSerializer xs = new XmlSerializer(typeof(MessageInfo));
                        MessageInfo mInfo = new MessageInfo();
                        MessageTable mt = new MessageTable();
                        mInfo.Message = message;
                        mInfo.Date = DateTime.Now;
                        mt.Message = mInfo.Message;
                        mt.Date = mInfo.Date;
                        //Serialiserar message info klass objekt till en xml fil som skall användas för att visa senaste meddelande på webbsidan
                        xs.Serialize(fs, mInfo);

                        //Lägger in data i ORMet
                        dbContext.MessageTables.InsertOnSubmit(mt);

                        //Exkeverar sqlsats till databasen
                        dbContext.SubmitChanges();

                        Console.WriteLine(" Message successfully sent!");
                    }
                    //Fångar eventuella exceptions och beskriver vad det är för fel
                    //Readkey använder jag för man skall kunna läsa av felkoden innan konsoll applikationen avslutas, annars avslutas programmer raskt efter Console.Writeline();.
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.ReadKey();
                    }
                    //Kommer stänga av filestreamen fs vare sig det blir felfritt eller inte, denna kodsnutt körs oavsett
                    finally
                    {
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.ReadKey();
                }
            }
        }   
    }
}
