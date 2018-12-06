using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Logic
{
    [Serializable]
    [XmlInclude(typeof(Station))]
    [DataContract(Namespace = ""), KnownType(typeof(ExpressTrain))]
    public class ExpressTrain:Train
    {
        protected ExpressTrain() : base()
        {

        }
        public ExpressTrain(TrainInfoHolder trainInfoHolder, string id) :base(trainInfoHolder, id)
        {
            
        }

        [DataMember]
        public override List<Station> IntermediateStations
        {
            get => new List<Station>();
        }
    }
}
