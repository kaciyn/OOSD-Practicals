using System.Runtime.Serialization;

namespace Logic
{
    [DataContract, KnownType(typeof(StoppingTrain))]
    public class StoppingTrain : Train
    {

//        public StoppingTrain(string id, TrainInfoStub trainInfoStub)
//        {
//            base.ID = id;//todo make id gen here??
//        }

//        public StoppingTrain():base
//        {
//            base;
//        }
    }
}
