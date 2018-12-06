using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Logic
{
    [Serializable]
    [XmlInclude(typeof(Station))]
    [DataContract(Namespace = ""), KnownType(typeof(StoppingTrain))]
    public class StoppingTrain : Train
    {
        protected StoppingTrain(): base()
        {

        }
        public StoppingTrain(TrainInfoHolder trainInfoHolder, string id) : base(trainInfoHolder, id)
        {

        }
    }
}
