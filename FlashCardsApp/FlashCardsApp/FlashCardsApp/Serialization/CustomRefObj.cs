using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardsApp.Serialization
{
    class CustomRefObj
    {
        public string VariableName { get; private set; }
        public Int64 ObjectUID { get; private set; }
        public Type ObjectType { get; private set; }

        public CustomRefObj(string varName, Int64 objUID, Type objType)
        {
            VariableName = varName;
            ObjectUID = objUID;
            ObjectType = objType;
        }
    }
}
