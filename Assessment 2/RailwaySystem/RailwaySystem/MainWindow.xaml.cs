using Data;
using Logic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace RailwaySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        readonly DataFacade.DataFacadeSingleton dataFacade = DataFacade.DataFacadeSingleton.GetInstance();

        private ObservableCollection<Train> trains;//all trains in system

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            UpdateCurrentData();

            SetTrainListToDefault();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            Language = XmlLanguage.GetLanguage("en-GB");

            ddDeparture.ItemsSource = ValidStations.Stations.Select(station => station.Name).ToList();
            ddDestination.ItemsSource = ValidStations.Stations.Select(station => station.Name).ToList();

            lstviewTrains.ItemsSource = dataFacade.GetAllTrains().ToObservableCollection();

        }


        /// <summary>
        /// Updates local observable collections from persistent data
        /// </summary>
        public void UpdateCurrentData()
        {
            lstviewTrains.ItemsSource = dataFacade.GetAllTrains().ToObservableCollection();

            lstviewTrains.UpdateLayout();
        }

        /// <summary>
        /// Finds and displays all bookings info for selected train.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void lstviewTrains_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selectedTrain = (Train)lstviewTrains.SelectedItem;
                var selectedTrainID = selectedTrain.ID;

                lstviewBookings.ItemsSource = dataFacade.FindBookingsOnTrain(selectedTrainID);

                lstviewTrains.UpdateLayout();
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
                addTrainWindow.Closing += AddWindowOnClosing;
                break;
                case "AddBooking":
                var addBookingWindow = new AddBooking();
                addBookingWindow.Show();
                addBookingWindow.Closing += AddWindowOnClosing;
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

        private void AddWindowOnClosing(object sender, CancelEventArgs e)
        {
            UpdateCurrentData();
        }

        private void FilterTrains(string filterBy)
        {
            switch (filterBy)
            {
                case "Stations":
                lstviewTrains.ItemsSource = GetTrainsRunningBetweenStations() ?? dataFacade.GetAllTrains().ToObservableCollection();
                break;
                case "Departure":
                lstviewTrains.ItemsSource = GetTrainsRunningOnDate() ?? dataFacade.GetAllTrains().ToObservableCollection();
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
            var departureStationName = ddDeparture.SelectedValue.ToString();
            var destinationStationName = ddDestination.SelectedValue.ToString();

            if (departureStationName == destinationStationName)
            {
                MessageBox.Show("Departure and Destination stations cannot be the same!");
                return null;
            }

            var departureStation = ValidStations.Stations.First(station => station.Name == departureStationName);

            var destinationStation = ValidStations.Stations.First(station => station.Name == destinationStationName);

            var londonBound =
                ValidStations.Stations.IndexOf(
                    departureStation) <
                ValidStations.Stations.IndexOf(destinationStation); //finds out if the desired train is London-bound or not; list of valid train stations is ordered from Edinburgh to London

            ObservableCollection<Train> trainsBetweenStations;

            if (londonBound)
            {
                trainsBetweenStations = dataFacade.GetAllTrains().ToObservableCollection().Where(train =>
                     train.DestinationStation.Name == ValidStations.Stations.Last().Name &&
                     (departureStation.Name == train.OriginStation.Name || train.IntermediateStations.Select(station => station.Name).Any()) &&
                     (destinationStation.Name == train.DestinationStation.Name || train.IntermediateStations.Select(station => station.Name).Any())).ToObservableCollection(); //gets trains going to London, and stopping at the stations desired
            }
            else
            {
                trainsBetweenStations = dataFacade.GetAllTrains().ToObservableCollection().Where(train =>
                    train.DestinationStation.Name == ValidStations.Stations.First().Name &&
                     (departureStation.Name == train.OriginStation.Name || train.IntermediateStations.Select(station => station.Name).Any()) &&
                     (destinationStation.Name == train.DestinationStation.Name || train.IntermediateStations.Select(station => station.Name).Any())).ToObservableCollection(); //gets trains going to Edinburgh, and stopping at the stations desired
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

            var trainsOnDate = dataFacade.GetAllTrains().ToObservableCollection().Where(train => train.DepartureDateTime.Date == dateSelected).ToObservableCollection();

            if (!trainsOnDate.Any())
            {
                MessageBox.Show("No trains on selected date found");
                return null;
            }

            return trainsOnDate;
        }

        private void SetTrainListToDefault()
        {
            lstviewTrains.ItemsSource = dataFacade.GetAllTrains().ToObservableCollection();
            lstviewTrains.UpdateLayout();
        }
    }
}