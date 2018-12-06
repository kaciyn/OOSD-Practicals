using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class Fare
    {
        /// <summary>
        /// Calculates the booking fare.
        /// </summary>
        /// <param name="booking">The booking.</param>
        /// <param name="trainType">The type.</param>
        /// <returns></returns>
        public static int CalculateFare(Booking booking,Train.TrainType trainType)
        {
            int fare;
            if (ValidStations.Stations.Where(station => station.Type == Station.StationType.Endpoint).Contains(booking.DestinationStation) && ValidStations.Stations.Where(station => station.Type == Station.StationType.Endpoint).Contains(booking.DepartureStation))//If the booking is from end-to-end (LND-EDI or vice versa)
            {
                fare = 50;
            }
            else
            {
                fare = 25;
            }

            if (booking.FirstClass)
            {
                fare = fare + 10;
            }

            if (trainType == Train.TrainType.Sleeper)
            {
                fare = fare + 10;
            }

            if (booking.Cabin)
            {
                fare = fare + 20;
            }

            return fare;
        }
    }
}
