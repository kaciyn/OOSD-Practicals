using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Logic
{
    [DataContract, KnownType(typeof(ExpressTrain))]
    public class ExpressTrain:Train
    {

//        public ExpressTrain(string id, TrainInfoStub trainInfoStub)
//        {
//            base.ID = id;//todo make id gen here??
//        }

        public override List<Station> IntermediateStations
        {
            get => null;
        }
    }
}
