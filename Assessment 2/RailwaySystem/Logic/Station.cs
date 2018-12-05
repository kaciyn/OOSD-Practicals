using System.Runtime.Serialization;

namespace Logic
{
    [DataContract, KnownType(typeof(Station))]
    public class Station
    {
        public enum StationType
        {
            Endpoint, Intermediate
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public StationType Type { get; set; }
    }
}
