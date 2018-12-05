using Logic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Data
{
    [DataContract]
    public class Trains
    {
        [DataMember]
        public List<Train> trains = new List<Train>();

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
            return trains.Find(train => train.ID == id);
        }
    }
}