using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Console_Application
{
    [Serializable]
    public class MessageInfo
    {
        public string Message;
        public string Date;
        /* Om man vill lägga till en till egenskap till klassen och om den exempelvis är en automatisk uträkning 
        kan du använda [NonSerialized] innan fältet för att undvika att spara all för oviktig data som kan 
        genereras när den deserializeras istället. Men den automatiska uträkningens värde måste vara uträknad 
        innan den deserializerade objektet används, då ska man lägga till interfacet IDeserializationCallback till klassen och 
        använda sig utav IDeserialization.OnDeserialization(object sender) metoden med uträkningen i metoden.
        Jag använder mig utav binaryformatter i det här fallet för bästa bruk, men man kan också använda soapformatter som gör det mer tillgängligare 
        för applikationer som inte tillhör .NET.
         
        Om programmet ska kunna användas som webservice till andra operativsystem så använder jag hellre xml-serialization
        men jag kommer använda standard .Net serialization*/
    }
}
