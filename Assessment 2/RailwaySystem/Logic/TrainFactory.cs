using System;
using System.Security.Cryptography;

namespace Logic
{
    /// <summary>
    /// Train factory, spits out trains
    /// </summary>
    public class TrainFactory
    {
        /// <summary>
        /// Creates the train.
        /// </summary>
        /// <param name="trainInfoHolder">The train information holder.</param>
        /// <returns></returns>
        public Train CreateTrain(TrainInfoHolder trainInfoHolder)
        {
            var type = trainInfoHolder.Type;


            switch (type)
            {
                case Train.TrainType.Express:
                return new ExpressTrain(trainInfoHolder, GenerateTrainID("E"));
                case Train.TrainType.Stopping:
                return new StoppingTrain(trainInfoHolder, GenerateTrainID("I"));
                case Train.TrainType.Sleeper:
                return new SleeperTrain(trainInfoHolder, GenerateTrainID("S"));
                default:
                return null;
            }
        }

        /// <summary>
        /// Generates a random train id.
        /// </summary>
        /// <param name="typeCode">The type code.</param>
        /// <returns></returns>
        private string GenerateTrainID(string typeCode)
        {
            var bytes = new byte[4];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(bytes);
            var random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            var randomNumericIdPart = random.ToString().Substring(0, 3);

            var id = randomNumericIdPart.Insert(1, typeCode);

            return id;
        }
    }
}