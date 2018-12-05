using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Logic;

namespace Data
{
    class XmlSerialiser
    {
        public static void SerialiseItem<T>(string filepath, T item)
        {
            if (item == null)
            {
                Console.WriteLine("Item cannot be null");
                return;
            }

            try
            {
                var xmlDocument = new XmlDocument();
                var serialiser = new XmlSerializer(item.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serialiser.Serialize(stream, item);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(filepath);
                    stream.Close();
                }
                Console.WriteLine("Save successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void DeserialiseItem(string type,string filename )
        {
            Console.WriteLine("Reading with Stream");
            // Create an instance of the XmlSerializer.

            if (type=="Train")
            {
                var serializer = new XmlSerializer(typeof(Train));

                // Declare an object variable of the type to be deserialized.
                Train train;

                using (Stream reader = new FileStream(filename, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    train = (Train)serializer.Deserialize(reader);
                }

            }
            else if (type=="Booking")
            {
                var serializer = new XmlSerializer(typeof(Booking));
            }
           }

    }
}
