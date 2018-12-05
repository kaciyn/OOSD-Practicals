using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Facade for bookings in the system, contains a list of passengers and a method to find
    /// </summary>
    public class Bookings
    {
        private ObservableCollection<Booking> _list = new ObservableCollection<Booking>();

        /// <summary>
        /// Adds the specified new booking.
        /// </summary>
        /// <param name="newBooking">The new booking.</param>
        public void Add(Booking newBooking)
        {
            _list.Add(newBooking);
        }

        /// <summary>
        /// Finds train by its ID
        /// </summary>
        /// <param name="trainID">The train identifier.</param>
        /// <returns></returns>
        public List<Booking> FindByTrainID(string trainID)
        {
            var bookingsOnTrain=new List<Booking>();

            foreach (Booking booking in _list)
            {

                if (trainID == booking.TrainID)
                {
                    bookingsOnTrain.Add(booking);
                }
            }
            return bookingsOnTrain;
        }

//        public List<int> IDs
//        {
//            get
//            {
//                List<int> res = new List<int>();
//                foreach (Booking p in _list)
//                    res.Add(p.TrainID);
//                return res;
//            }
//        }
    }
}
