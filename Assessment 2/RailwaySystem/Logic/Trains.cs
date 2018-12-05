using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Trains
    {
        private ObservableCollection<Train> _list = new ObservableCollection<Train>();

        public void Add(Train newBooking)
        {
            _list.Add(newBooking);
        }

      //        public List<Train> FindByTrainID(string trainID)
        //        {
        //            var bookingsOnTrain = new List<Train>();
        //
        //            foreach (Train booking in _list)
        //            {
        //                if (trainID == booking.TrainID)
        //                {
        //                    bookingsOnTrain.Add(booking);
        //                }
        //            }
        //            return bookingsOnTrain;
        //        }
    }
}
