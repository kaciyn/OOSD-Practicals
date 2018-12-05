using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace Data
{
    public class Serialisers
    {
        private static readonly string storagePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Storage\\";

        public static void TrainSerialiser(List<Train> trains)
        {
            Directory.CreateDirectory(storagePath);

            //todo this gotta be the actual train id
            var serializer = new DataContractSerializer(typeof(List<Train>));

            var storageFilename = "Trains.xml";

            var filepath = storagePath + storageFilename;

            //            if (!File.Exists(filepath))
            //            {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(filepath, xmlWriterSettings))
            {
//                foreach (var train in trains)
//                {
                
                    serializer.WriteObject(xmlWriter, trains);
//                }
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            //            }


            //
            //idk if this is better
            //                var xmlDocument = XDocument.Load(filepath);
            //               
            //                XElement trainXmlElement = new XElement("Trains",
            //                    trainDb.db.Select(trainEntry => new XElement(trainEntry.Key, trainEntry.Value)));
            //

            //                Element to Dictionary:
        }

        //        private void TrainDeserialiser(TrainDatabase trainDb)
        //        {
        //            XElement rootElement = XElement.Parse("<root><key>value</key></root>");
        //            Dictionary<string, string> dict = new Dictionary<string, string>();
        //            foreach (var el in rootElement.Elements())
        //            {
        //                dict.Add(el.Name.LocalName, el.Value);
        //            }
        //        }

        private void BookingDeserialiser(BookingDatabase bookingDb)
        {
            var serialiser = new DataContractSerializer(typeof(Trains));

            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    serialiser.WriteObject(xmlTextWriter, bookingDb);
                    xmlTextWriter.Flush();
                }
            }


        }
    }
}
