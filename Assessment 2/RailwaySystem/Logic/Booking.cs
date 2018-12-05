using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logic
{
    /// <summary>
    /// A booking on a train
    /// </summary>
    [Serializable]
    public class Booking
    {
        private string _name;
        //todo validate duplicate bookings
        /// <summary>
        /// Passenger name
        /// </summary>
        /// <exception cref="System.ArgumentException">Name cannot be blank</exception>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(_name))
                {
                    throw new ArgumentException("Name cannot be blank");
                }
                _name = value;
            }
        }

        //todo may need to sort out whether the train is going in the correct direction lol and also stopping at the station yeah actually absolutely
        private Station _departureStation;
        /// <summary>
        /// The departure station, must be in list of valid stations and cannot be same as destination station
        /// </summary>
        /// <value>
        /// The departure station.
        /// </value>
        /// <exception cref="System.ArgumentException">
        /// Invalid departure station
        /// or
        /// Departure station cannot be same as destination station!
        /// </exception>
        public Station DepartureStation
        {
            get => _departureStation;
            set
            {
                if (ValidStations.Stations.All(station => station != value))
                {
                    throw new ArgumentException("Invalid departure station");
                }
                if (value == _destinationStation)
                {
                    throw new ArgumentException("Departure station cannot be same as destination station!");
                }
                _departureStation = value;
            }
        }


        private Station _destinationStation;
        /// <summary>
        /// The destination station, must be in list of valid stations and cannot be same as destination station
        /// </summary>
        /// <value>
        /// The destination station.
        /// </value>
        /// <exception cref="System.ArgumentException">
        /// Invalid destination station
        /// or
        /// Destination station cannot be same as departure station!
        /// </exception>
        public Station DestinationStation
        {
            get => _destinationStation;
            set
            {
                if (ValidStations.Stations.All(station => station != value))
                {
                    throw new ArgumentException("Invalid destination station");
                }
                if (value == _departureStation)
                {
                    throw new ArgumentException("Destination station cannot be same as departure station!");
                }
                _destinationStation = value;
            }
        }

        private bool _firstClass;
        /// <summary>
        /// Indicates if the booking is first class or not, can only be true if train offers first class
        /// </summary>
        /// <value>
        ///   <c>true</c> if [first class]; otherwise, <c>false</c>.
        /// </value>
        public bool FirstClass
        {
            get { return _firstClass; }
            set
            {
                if (FirstClass)
                {
                    //todo this should be validated against train offering first class
                }
                if (value == true)
                {

                }
                _firstClass = value;
            }
        }

        //todo if this is true i think the seat needs to be null and cabin stands in for the seat, idk if to treat the cabin as a single seat???
        private bool _cabin;
        /// <summary>
        /// Indicates if the passenger has booked a cabin, can only true if the train is a sleeper
        /// </summary>
        /// <value>
        ///   <c>true</c> if cabin; otherwise, <c>false</c>.
        /// </value>
        public bool Cabin
        {
            get { return _cabin; }
            set { _cabin = value; }
        }

        private string _coach;
        /// <summary>
        /// The passenger's coach
        /// </summary>
        /// <value>
        /// The coach.
        /// </value>
        public string Coach
        {
            get => _coach;
            set
            {
                var allowedCoachesRegex = new Regex(@"^[A-H]{1}$");
                if (!allowedCoachesRegex.IsMatch(value))
                {
                    throw new ArgumentException("Coach needs to be a single letter A-H");
                }
                _coach = value;
            }
        }

        private int _seat;
        /// <summary>
        /// The passenger's seat number
        /// </summary>
        /// <value>
        /// The seat.
        /// </value>
        /// <exception cref="System.ArgumentException">Seat number needs to be from 1-60</exception>
        public int Seat
        {
            get => _seat;
            set
            {
                if (value<1||value>60)
                {
                    throw new ArgumentException("Seat number needs to be from 1-60");
                }
                _seat = value;
            }
        }

             /// <summary>
        /// The id of the train the the booking is for
        /// </summary>
        /// <value>
        /// The train identifier.
        /// </value>
        public string TrainID { get; set; }


        public Train GetTrain(string trainID)
        {
            return new ExpressTrain();
        }
        //        public int CalculateFare(Booking booking)
        //        {
        //            int fare;
        //            if (ValidStations.Stations.Where(station => station.Type == Station.StationType.Endpoint).Contains(DestinationStation) && ValidStations.Stations.Where(station => station.Type == Station.StationType.Endpoint).Contains(DepartureStation))
        //            {
        //                fare = 50;
        //            }
        //            else
        //            {
        //                fare = 25;
        //            }
        //
        //            if (booking.FirstClass)
        //            {
        //                fare = fare + 10;
        //            }
        //
        //            if (booking.GetTrain().Type == Train.TrainType.Sleeper)
        //            {
        //                fare = fare + 10;
        //            }
        //
        //            if (booking.Cabin)
        //            {
        //                //todo define some amount of cabins the train has say 2 per coach because like does it really matter
        //                //todo the decorator might be good for cabin bookings as it doesn't have the classical seat thing
        //
        //            }
        //
        //            return fare;
        //        }
    }

}
