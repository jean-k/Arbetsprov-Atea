using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Message_Console_Application;

namespace MessageReceiver_Webapp
{
    public partial class Message : System.Web.UI.Page
    {
        HandleMessages hm = new HandleMessages();
        List<MessageList> lstConsolMessages = new List<MessageList>();
        protected void Page_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(hm.savePath, FileMode.Open);

            //lstConsolMessages = (MessageList) 
            gdMessages.DataSource = lstConsolMessages;
            gdMessages.DataBind();
        }

        protected void tmrRefresh_Tick(object sender, EventArgs e)
        {

        }
    }
}