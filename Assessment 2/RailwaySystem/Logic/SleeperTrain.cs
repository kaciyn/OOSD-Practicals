using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Logic
{
    [DataContract, KnownType(typeof(SleeperTrain))]
    public class SleeperTrain : Train
    {
//        public SleeperTrain(string id, TrainInfoStub trainInfoStub)
//        {
//            base.ID = id;//todo make id gen here??
//        }

        private DateTime _departure;
        public override DateTime DepartureDateTime
        {
            get => _departure;
            set
            {
                if (value.TimeOfDay<new TimeSpan(21, 0, 0))
                {
                    throw new ArgumentException("Sleeper train cannot depart before 21:00");
                }
                _departure = value;
            }
        }

        private bool _sleeperBerth;
        public override bool SleeperBerth
        {
            get => _sleeperBerth;
            set => _sleeperBerth = true;
        }

        public bool Cabin { get; set; }
    }
}
