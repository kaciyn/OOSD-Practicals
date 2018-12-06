using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Logic
{
    /// <summary>
    /// A booking on a train
    /// </summary>
    [XmlInclude(typeof(Station))]
    [DataContract(Namespace = ""), KnownType(typeof(Booking))]
    public class Booking
    {
        private string _name;
        /// <summary>
        /// Passenger name
        /// </summary>
        /// <exception cref="System.ArgumentException">Name cannot be blank</exception>
        [DataMember]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be blank");
                }
                _name = value;
            }
        }

        [DataMember]
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
        [DataMember]
        public Station DepartureStation
        {
            get => _departureStation;
            set
            {
                if (ValidStations.Stations.All(station => station.Name != value.Name))
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
        [DataMember]
        public Station DestinationStation
        {
            get => _destinationStation;
            set
            {
                if (ValidStations.Stations.All(station => station.Name != value.Name))
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
        [DataMember]
        public bool FirstClass
        {
            get { return _firstClass; }
            set
            {
                if (FirstClass)
                {
                }
                if (value == true)
                {

                }
                _firstClass = value;
            }
        }

        private bool _cabin;
        /// <summary>
        /// Indicates if the passenger has booked a cabin, can only true if the train is a sleeper; assuming one cabin per coach
        /// </summary>
        /// <value>
        ///   <c>true</c> if cabin; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
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
        [DataMember]
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
        /// The passenger's seat number, 0 if passenger has booked a cabin
        /// </summary>
        /// <value>
        /// The seat.
        /// </value>
        /// <exception cref="System.ArgumentException">Seat number needs to be from 1-60</exception>
        [DataMember]
        public int Seat
        {
            get => _seat;
            set
            {
                if (Cabin)
                {
                    value = 0;
                }
                else if (value < 1 || value > 60)

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
        [DataMember]
        public string TrainID { get; set; }
    }
}
