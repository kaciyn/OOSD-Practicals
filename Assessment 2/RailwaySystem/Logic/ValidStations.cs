using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Valid train stations
    /// </summary>
    public static class ValidStations
    {
        public static List<Station> Stations { get; set; } = new List<Station>
        {
            new Station {Name = "Edinburgh (Waverly)", Type = Station.StationType.Endpoint},
            new Station {Name = "York", Type = Station.StationType.Intermediate},
            new Station {Name = "Newcastle", Type = Station.StationType.Intermediate},
            new Station {Name = "Darlington", Type = Station.StationType.Intermediate},
            new Station {Name = "Peterborough", Type = Station.StationType.Intermediate},
            new Station {Name = "London (King's Cross)", Type = Station.StationType.Endpoint}
        };
    }
}