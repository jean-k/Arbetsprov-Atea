using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Console_Application
{
    //Ett best practise är att ha serializable på klasser man skapar
    [Serializable]
    public class MessageInfo
    {
        public string Message;
        public DateTime Date;
        /* Om man vill lägga till en till egenskap till klassen och om den exempelvis är en automatisk uträkning 
        kan du använda [NonSerialized] innan fältet för att undvika att spara all för oviktig data som kan 
        genereras när den deserializeras istället. Men den automatiska uträkningens värde måste vara uträknad 
        innan den deserializerade objektet används, då ska man lägga till interfacet IDeserializationCallback till klassen och 
        använda sig utav IDeserialization.OnDeserialization(object sender) metoden med uträkningen i metoden.
        Jag använder mig utav xmlserializer eftersom det gör data läsbart samt att admin kan lätt ändra på data. Det hade varit
        svårare att ändra data om det hade varit binärt serializerat, dv.s med hjälp avbinaryformatter, varje serialization klass har sin
        för och nackdel, xmlserializer är bra främst som en opåverkad datafil som kan deserializeras av olika program samt operativsystem.*/
    }
}
