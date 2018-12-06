using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Data
{
    [DataContract(Namespace = ""), KnownType(typeof(List<Train>))]
    public class BookingDb
    {
        [DataMember] public List<Booking> bookings = Serialisers.GetBookings();

        /// <summary>
        /// Adds a new booking.
        /// </summary>
        /// <param name="newBooking">The new booking.</param>
        /// <exception cref="System.Exception">Cannot double-book a seat on a single train</exception>
        public void Add(Booking newBooking)
        {
            if (bookings.Find(booking => booking.TrainID == newBooking.TrainID&& (booking.Seat == newBooking.Seat || booking.Coach == newBooking.Coach) && booking.Coach == newBooking.Coach) != null)
            {
                throw new Exception("Cannot double-book a seat/cabin on a single train");
            }

            bookings.Add(newBooking);
        }
        }
}
