using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FlashCardsApp.Serialization
{
    interface ICustomSerializable
    {
        long UID { get; set; }

        List<CustomRefObj> ObjectRefs { get; set; }

        FieldInfo[] GetAllFields();

        PropertyInfo[] GetAllProperties();
    }
}
