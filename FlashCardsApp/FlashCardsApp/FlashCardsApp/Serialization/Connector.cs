using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FlashCardsApp.Serialization
{
    class Connector
    {
        public void Disconnect(ICustomSerializable obj, List<ICustomSerializable> allObjects)
        {
            List<CustomRefObj> objRefObjects = obj.ObjectRefs;

            Type t = obj.GetType();

            FieldInfo[] objFields = obj.GetAllFields();//typeof(Type).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            PropertyInfo[] objProperties = obj.GetAllProperties();


            //for(int i = 0; i < )
            //{

            //}
        }
    }
}
