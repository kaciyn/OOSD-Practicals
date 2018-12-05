using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TrainInfoStub
    {
        public Train.TrainType Type { get; set; }
        public DateTime DepartureTime { get; set; }
        public Station OriginStation { get; set; }
        public Station DestinationStation { get; set; }
        public List<Station> IntermediateStations { get; set; }
        public bool OffersFirstClass { get; set; }
    }
}
