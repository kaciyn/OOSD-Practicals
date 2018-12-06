using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Logic
{
    [Serializable]
    [XmlInclude(typeof(Station))]
    [DataContract(Namespace = ""), KnownType(typeof(Station))]
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
