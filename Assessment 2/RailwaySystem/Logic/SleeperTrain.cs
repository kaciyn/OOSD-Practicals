using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Logic
{
    [Serializable]
    [XmlInclude(typeof(Station))]
    [DataContract(Namespace = ""), KnownType(typeof(SleeperTrain))]
    public class SleeperTrain : Train
    {
        protected SleeperTrain() : base()
        {

        }
        public SleeperTrain(TrainInfoHolder trainInfoHolder, string id) : base(trainInfoHolder, id)
        {

        }
        private DateTime _departure;
        [DataMember]
        public override DateTime DepartureDateTime
        {
            get => _departure;
            set
            {
                if (value.TimeOfDay < new TimeSpan(21, 0, 0))
                {
                    throw new ArgumentException("Sleeper train cannot depart before 21:00");
                }
                _departure = value;
            }
        }

        private bool _sleeperBerth;
        [DataMember]
        public override bool SleeperBerth
        {
            get => _sleeperBerth;
            set => _sleeperBerth = true;
        }
    }
}
