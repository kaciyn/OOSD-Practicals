using System;
using System.Collections.Generic;

namespace Logic
{
    public class TrainInfoHolder
    {
        public Train.TrainType Type { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public Station OriginStation { get; set; }
        public Station DestinationStation { get; set; }
        public List<Station> IntermediateStations { get; set; }
        public bool OffersFirstClass { get; set; }
        public bool Cabin { get; set; }
    }
}
