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
    public class HandleMessages
    {
        public string savePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\MessageData\\MessageData.xml";
        MessageInfo mInfo = new MessageInfo();
        public void SaveMessage(string message)
        {
            if (message != null)
            {
                try
                {
                    mInfo.Message = message;
                    mInfo.Date = string.Format("{0:MM/dd/yy H:mm:ss}", DateTime.Now.ToString());
                    FileStream fs = new FileStream(savePath, FileMode.Create);
                    try
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(MessageInfo));
                        xs.Serialize(fs, mInfo);
                        Console.WriteLine(" Message successfully sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }   
    }
}
