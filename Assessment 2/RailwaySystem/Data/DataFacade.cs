using Logic;
using System.Collections.Generic;

namespace Data
{
    public class DataFacade
    {
        public class DataFacadeSingleton
        {
            //Singleton code
            private static DataFacadeSingleton reference;

            private DataFacadeSingleton() { }

            public static DataFacadeSingleton GetInstance()
            {
                return reference ?? (reference = new DataFacadeSingleton());
            }

            private TrainDb trainDb = new TrainDb();

            /// <summary>
            /// Adds train to list of trains.
            /// </summary>
            /// <param name="train">The train.</param>
            public void AddTrain(Train train)
            {
                trainDb.Add(train);
            }

            /// <summary>
            /// Gets train with specified id
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <returns></returns>
            public Train GetTrain(string id)
            {
                return trainDb.Get(id);
            }

            public void SaveTrains()
            {
                Serialisers.TrainSerialiser(trainDb.trains);
            }

            public List<Train> GetAllTrains()
            {
                return trainDb.trains;
            } 


            private BookingDb bookingDb = new BookingDb();

            /// <summary>
            /// Adds Booking to list of Bookings.
            /// </summary>
            /// <param name="Booking">The Booking.</param>
            public void AddBooking(Booking Booking)
            {
                bookingDb.Add(Booking);
            }

            public void SaveBookings()
            {
                Serialisers.BookingSerialiser(bookingDb.bookings);
            }

            /// <summary>
            /// Finds the bookings on train.
            /// </summary>
            /// <param name="trainID">The train identifier.</param>
            /// <returns></returns>
            public List<Booking> FindBookingsOnTrain(string trainID)
            {
                var bookingsOnTrain = new List<Booking>();

                foreach (Booking booking in bookingDb.bookings)
                {

                    if (trainID == booking.TrainID)
                    {
                        bookingsOnTrain.Add(booking);
                    }
                }
                return bookingsOnTrain;
            }
        }
    }
}
