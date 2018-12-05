using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace RailwaySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Bookings bookings = new Bookings();//all bookings in system
        private ObservableCollection<Train> trains = new ObservableCollection<Train>();//all trains in system
                                                                                       //do same like bookings wrapper?? is that a wrapper??????
        private UIElementCollection allWindowElements;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Trains();
            //            };//todo test on a couple trains tomor
            //            //todo set some of the booking properties according to the train values
            ////            bookings.Add(new Booking{Name = "Kaci",DestinationStation = ValidStations});
            //            var windowPanel = (Panel)Content; //gets contents of MainWindow
            //            allWindowElements = windowPanel.Children; //gets all UI elements in window
            //
            //            SetTrainListToDefault();
            //
            //            ddDeparture.ItemsSource = ValidStations.Stations;
            //            ddDestination.ItemsSource = ValidStations.Stations;
        }

        public void Trains()
        {
            var stopint = new List<Station>
                {ValidStations.Stations[1], ValidStations.Stations[3], ValidStations.Stations[4]};
            var int2 = ValidStations.Stations.Where(station => station.Type == Station.StationType.Intermediate).Skip(2)
                .Take(1).ToList();


            var trains = new ObservableCollection<Train>
            {

                new ExpressTrain
                {
                    ID = "1S45", Type = Train.TrainType.Express,
                    DepartureDateTime = new DateTime(2018, 11, 1, 10, 0, 0),
                    DestinationStation = ValidStations.Stations.First(), OriginStation = ValidStations.Stations.Last(),
                    IntermediateStations = int2, OffersFirstClass = true
                },

                new SleeperTrain
                {
                    ID = "1E99", Type = Train.TrainType.Sleeper,
                    DepartureDateTime = new DateTime(2018, 11, 1, 21, 30, 0),
                    DestinationStation = ValidStations.Stations.Last(), OriginStation = ValidStations.Stations.First(),
                    OffersFirstClass = true
                },

                new StoppingTrain
                {
                    ID = "1E05", DepartureDateTime = new DateTime(2018, 11, 1, 12, 0, 0),
                    Type = Train.TrainType.Stopping, DestinationStation = ValidStations.Stations.Last(),
                    OriginStation = ValidStations.Stations.First(), IntermediateStations = stopint,
                    OffersFirstClass = true
                }
            };

            DataFacade.DataFacadeSingleton dataFacade = DataFacade.DataFacadeSingleton.GetInstance();
            //Save the module
            foreach (var train in trains)
            {
                dataFacade.Add(train);
            }

            dataFacade.SaveTrains();
        }

        /// <summary>
        /// Finds and displays all bookings info for selected train.
        /// </summary>
        private void lstviewTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedTrain = (Train)lstviewTrains.SelectedItem;
                var selectedTrainID = selectedTrain.ID;

                lstviewBookings.ItemsSource = bookings.FindByTrainID(selectedTrainID);
                lstviewTrains.UpdateLayout();
            }
            catch (Exception emptyCustomerCollection) when (emptyCustomerCollection.Message ==
                                                            "Object reference not set to an instance of an object.")//todo update this if you get the error on run
            {
                //                ClearTextBoxesWithTag("DisplayInfo");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Tag)
            {
                case "AddTrain":
                var addTrainWindow = new AddTrain();
                addTrainWindow.Show();
                break;
                case "AddBooking":
                var addBookingWindow = new AddBooking();
                addBookingWindow.Show();
                break;
                case "Reset":
                SetTrainListToDefault();
                break;
                case "FilterStations":
                FilterTrains("Stations");
                break;
                case "FilterDeparture":
                FilterTrains("Departure");
                break;
                case null:
                throw new Exception("Untagged button pressed");
                default:
                throw new Exception("Unknown button pressed");
            }
        }

        private void FilterTrains(string filterBy)
        {
            switch (filterBy)
            {
                case "Stations":
                lstviewTrains.ItemsSource = GetTrainsRunningBetweenStations() ?? trains;
                break;
                case "Departure":
                lstviewTrains.ItemsSource = GetTrainsRunningOnDate() ?? trains;
                break;
                default:
                throw new Exception("Unknown filter");
            }

            lstviewTrains.UpdateLayout();
        }

        /// <summary>
        /// Returns the trains that run between the two stations selected.
        /// </summary>
        private ObservableCollection<Train> GetTrainsRunningBetweenStations()
        {
            var departureStationName = (Station)ddDeparture.SelectedValue;
            var DestinationStationName = (Station)ddDestination.SelectedValue;

            if (departureStationName == DestinationStationName)
            {
                MessageBox.Show("Departure and Destination stations cannot be the same!");
                return null;
            }

            //todo  see if u can't get the value as a station object

            var departureStation = departureStationName;

            var DestinationStation = DestinationStationName;

            //            var departureStation = ValidStations.Stations.First(station => station.Name == departureStationName);
            //
            //            var DestinationStation = ValidStations.Stations.First(station => station.Name == DestinationStationName);

            var londonBound =
                ValidStations.Stations.IndexOf(
                    departureStation) <
                ValidStations.Stations.IndexOf(DestinationStation); //finds out if the desired train is London-bound or not; list of valid train stations is ordered from Edinburgh to London
            //todo it seems to think this is always true, INVESTIGATE!!!!!

            ObservableCollection<Train> trainsBetweenStations;

            if (londonBound)
            {
                trainsBetweenStations = trains.Where(train =>
                     train.DestinationStation == ValidStations.Stations.Last() == londonBound &&
                     (departureStation == train.OriginStation || train.IntermediateStations.Any()) &&
                     (DestinationStation == train.DestinationStation || train.IntermediateStations.Any())).ToObservableCollection(); //gets trains going to London, and stopping at the stations desired
            }
            else
            {
                trainsBetweenStations = trains.Where(train =>
                    train.DestinationStation == ValidStations.Stations.Last() != londonBound &&
                     (departureStation == train.OriginStation || train.IntermediateStations.Any()) &&
                     (DestinationStation == train.DestinationStation || train.IntermediateStations.Any())).ToObservableCollection(); //gets trains going to Edinburgh, and stopping at the stations desired
            }

            if (!trainsBetweenStations.Any())
            {
                MessageBox.Show("No trains going between selected stations found");
                return null;
            }

            return trainsBetweenStations;
        }

        /// <summary>
        /// Gets the trains running on selected date.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<Train> GetTrainsRunningOnDate()
        {
            var dateSelected = dateDeparture.SelectedDate ?? DateTime.Today;

            var trainsOnDate = trains.Where(train => train.DepartureDateTime.Date == dateSelected).ToObservableCollection();

            if (!trainsOnDate.Any())
            {
                MessageBox.Show("No trains on selected date found");
                return null;
            }

            return trainsOnDate;
        }

        private void SetTrainListToDefault()
        {
            lstviewTrains.ItemsSource = trains;
            lstviewTrains.UpdateLayout();
        }

    }
}