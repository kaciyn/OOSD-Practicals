using System.Collections.Generic;
using Logic;

namespace Data
{
    public class DataFacade
    {
        public class DataFacadeSingleton
        {
            //Singleton code
            private static DataFacadeSingleton reference;

            private DataFacadeSingleton() { }

            public static DataFacadeSingleton GetInstance()
            { 
                return reference ?? (reference = new DataFacadeSingleton());
            }


            private List<Train> trains = new List<Train>();

            /// <summary>
            /// Adds train to list of trains.
            /// </summary>
            /// <param name="train">The train.</param>
            public void Add(Train train)
            {
                trains.Add(train);
            }

            //Get a Module object based on the supplied module code
            public Train Get(int code)
            {
                //                return db.get(code);
                return new ExpressTrain();
            }

            public void SaveTrains()
            {
                Serialisers.TrainSerialiser(trains);
            }
        }
    }
}
