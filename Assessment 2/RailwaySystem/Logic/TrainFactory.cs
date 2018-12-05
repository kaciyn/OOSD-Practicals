using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Logic
{
    public class TrainFactory
    {
//        public Train CreateTrain(TrainInfoStub trainInfoStub)
//        {
//            var type = trainInfoStub.Type;
//
//            var train=new Train
//            {
//                Type =trainInfoStub.Type,
//                OriginStation = trainInfoStub.OriginStation,
//                DestinationStation = trainInfoStub.DestinationStation,
//                DepartureDateTime = trainInfoStub.DepartureTime,
//                OffersFirstClass = trainInfoStub.OffersFirstClass
//            };
//
//            switch (type)
//            {
//                case Train.TrainType.Express:
//                    return new ExpressTrain(GenerateTrainID("E"),trainInfoStub);
//                case Train.TrainType.Stopping:
//                    return new StoppingTrain(GenerateTrainID("I"), trainInfoStub);
//                case Train.TrainType.Sleeper:
//                    return new SleeperTrain(GenerateTrainID("S"), trainInfoStub);
//                default:
//                    return null;//Default, can only create StudentAccount or CurrentAccount. If anything else is requested return null
//            }
//        }

        private string GenerateTrainID(string typeCode)
        {
            var bytes = new byte[3];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            var random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            var randomNumericIdPart = $"{random:D3}";

            var id = randomNumericIdPart.Insert(1, typeCode);
            return id;
        }
    }
}
//write create function that takes the stub i think and returns 