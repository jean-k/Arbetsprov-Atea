using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Message_Console_Application
{
    public class HandleMessages
    {
        public string savePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\MessageData\\MessageList.data";
        List<MessageList> lstMessages = new List<MessageList>();
        MessageList msgList = new MessageList();
        public void SaveMessage(string message)
        {
            if (message != null)
            {
                //Denna kod ser till så att mitt reserverade ord 'save' inte läggs till i listan av meddelanden
                if (message == "save")
                {
                    return;
                }
                msgList.Message = message;
                msgList.Date = DateTime.Now.ToString("u");
                lstMessages.Add(msgList);
            }
        }

        public bool SaveChanges()
        {
            try
            {
                FileStream fs = new FileStream(savePath, FileMode.Create);
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    /*Jag har lagt till en referens från console applikation projektet till webapplikations projektet för att dela 
                     ihop serializerad data under mappen MessageData på consol applikation projektet.*/
                    bf.Serialize(fs, lstMessages);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
