using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Message_Console_Application;
using System.Xml.Serialization;

namespace MessageReceiver_Webapp
{
    public partial class Message : System.Web.UI.Page
    {
        HandleMessages hm = new HandleMessages();
        List<MessageInfo> lstMessages = new List<MessageInfo>(); //get all messages from db
        protected void Page_Load(object sender, EventArgs e)
        {
            //load all messages fom db

            //FileStream fs = new FileStream(hm.savePath, FileMode.Open);
            //lstConsolMessages = (MessageList)
            //gdMessages.DataSource = lstConsolMessages;
            //gdMessages.DataBind();
        }


        //Metoden visar senaste meddelandet.
        protected void tmrRefresh_Tick(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath(Request.ApplicationPath);
                string filePath = Path.Combine(path.Substring(0, (path.Length - 24)), "Message Console Application\\MessageData\\MessageData.xml");
                FileStream fs = new FileStream(filePath, FileMode.Open);
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(MessageInfo));
                    MessageInfo msg = (MessageInfo)xs.Deserialize(fs);
                    fs.Close();
                    lstMessages.Add(msg);
                    Response.Write("<h1>" + msg.Message + " " + msg.Date + "</h1>");
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}