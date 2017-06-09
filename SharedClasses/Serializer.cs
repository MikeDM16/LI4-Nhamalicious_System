using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SharedClasses
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
            try
            {
                using (var memoryStream = new MemoryStream(message.Data))
                    return (new BinaryFormatter()).Deserialize(memoryStream);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return null;
        }
    }
}