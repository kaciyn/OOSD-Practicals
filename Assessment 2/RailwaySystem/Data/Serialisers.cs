using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Data
{
    public class Serialisers
    {
        private static readonly string storagePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\_PersistentStorage\\";
        private static readonly string trainStorageFilename = "Trains.xml";
        private static readonly string bookingStorageFilename = "Bookings.xml";

        public static void TrainSerialiser(List<Train> trains)
        {
            Directory.CreateDirectory(storagePath);

            var serializer = new DataContractSerializer(typeof(List<Train>));


            var filepath = storagePath + trainStorageFilename;


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(filepath, xmlWriterSettings))
            {
                serializer.WriteObject(xmlWriter, trains);
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }

        public static List<Train> GetTrains()
        {
            var filepath = storagePath + trainStorageFilename;
            return TrainDeserialiser(filepath);
        }

        public static List<Train> TrainDeserialiser(string filepath)
        {
            if (File.Exists(filepath))
            {
                var xmlDocument = XDocument.Load(filepath);
                var xmlRoot = new XmlRootAttribute { ElementName = "ArrayOfTrain" };

                var xmlSerializer = new XmlSerializer(typeof(List<Train>), xmlRoot);

                if (xmlDocument.Root != null)
                    using (var reader = xmlDocument.Root.CreateReader())
                    {
                        return (List<Train>)xmlSerializer.Deserialize(reader);
                    }
            }

            Console.WriteLine("No existing storage file detected, creating new list of trains");
            return new List<Train>();
        }

        public static void BookingSerialiser(List<Booking> bookings)
        {
            Directory.CreateDirectory(storagePath);

            var serializer = new DataContractSerializer(typeof(List<Booking>));


            var filepath = storagePath + bookingStorageFilename;


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Indent = true, NewLineOnAttributes = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(filepath, xmlWriterSettings))
            {
                serializer.WriteObject(xmlWriter, bookings);
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }

        public static List<Booking> GetBookings()
        {
            var filepath = storagePath + bookingStorageFilename;
            return BookingDeserialiser(filepath);
        }

        public static List<Booking> BookingDeserialiser(string filepath)
        {
            if (File.Exists(filepath))
            {
                var xmlDocument = XDocument.Load(filepath);
                var xmlRoot = new XmlRootAttribute { ElementName = "ArrayOfBooking" };

                var xmlSerializer = new XmlSerializer(typeof(List<Booking>), xmlRoot);

                if (xmlDocument.Root != null)
                    using (var reader = xmlDocument.Root.CreateReader())
                    {
                        return (List<Booking>)xmlSerializer.Deserialize(reader);
                    }
            }

            Console.WriteLine("No existing storage file detected, creating new list of bookings");
            return new List<Booking>();
        }
    }
}