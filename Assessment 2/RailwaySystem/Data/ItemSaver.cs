using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Data
{
    class ItemSaver
    {
        public void SaveItem<T>(T item, string type)
        {
            var storagePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Storage\\";
            string storageFilename;

            if (item is Train)
            {
                storageFilename = "Trains";

            }
            else if (item is Booking)
            {
                    storageFilename = "Bookings";

            }
            else
            {
                throw new Exception($"Unexpected item type: {item.GetType()}");

            }

            var filepath = storagePath + storageFilename;

            XmlSerialiser.SerialiseItem(filepath, item);
        }

        public void Load()
        {
            //todo 
        }
    }
}
