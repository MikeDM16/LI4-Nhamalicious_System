using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace ClassesPartilhadas.Classes
{
    public static class Serializer
    {
        public static AMessage Serialize(object anySerializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return new AMessage { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(AMessage message)
        {
            using (var memoryStream = new MemoryStream(message.Data))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }
    }
}