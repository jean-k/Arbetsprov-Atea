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
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Här behövs det inte binda koppling mellan databasen och gridview'n då jag i designläget kopplat ihop sqldatasource till gridview'n med standard query, select* allt. 
            Jag har valt att gömma MessageID på gridview'n för att få en snyggare tabell*/
        }

        //Eventet återskapar meddelandet från websiten som skapades från consol appen, med senaste meddelandet
        protected void tmrPartialUpdate_Tick(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath(Request.ApplicationPath) + "MessageData\\MessageData.xml";
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(MessageInfo));
                    MessageInfo msg = (MessageInfo)xs.Deserialize(fs);
                    lbl_message.InnerText = msg.Message;
                    lbl_date.InnerHtml = msg.Date.ToString();
                    RebindData();

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

        /* Uppdaterar databasens select sats samt konstruerar om gridviewn i updatepartial kontrollen 
        för att förhindra att hela sidan laddas om*/        
        void RebindData()
        {
            messageSourceConnection.DataBind();
            gdMessages.DataBind();
        }
    }
}