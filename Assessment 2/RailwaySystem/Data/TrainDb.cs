using Logic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract(Namespace = ""), KnownType(typeof(List<Train>))]
    public class TrainDb
    {
        [DataMember] public List<Train> trains = Serialisers.GetTrains();

        public void Add(Train newTrain)
        {
            if (trains.Find(train => train.ID == newTrain.ID) != null)
            {
                throw new Exception("Train with given ID already exists, cannot insert duplicate");
            }

            trains.Add(newTrain);
        }

        public Train Get(string id)
        {
            var foundTrain = trains.Find(train => train.ID == id);

            if (foundTrain == null)
            {
                throw new Exception("Train not found");
            }

            return foundTrain;
        }
    }
}