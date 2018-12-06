using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RailwaySystem
{
    /// <summary>
    /// Interaction logic for AddTrain.xaml
    /// </summary>
    public partial class AddTrain : Window
    {

        private UIElementCollection allWindowElements;
        private List<CheckBox> intermediateStationCheckboxes;
        private List<Station> intermediateStations;

        readonly DataFacade.DataFacadeSingleton dataFacade = DataFacade.DataFacadeSingleton.GetInstance();

        public AddTrain()
        {
            InitializeComponent();

            var windowPanel = (Panel)Content; //gets contents of MainWindow
            allWindowElements = windowPanel.Children; //gets all UI elements in window

            intermediateStationCheckboxes = allWindowElements.OfType<CheckBox>().Where(checkBox => (string)checkBox.Tag == "IntermediateStations").ToList(); //selects Intermediate Station checkboxes

            intermediateStations =
               ValidStations.Stations.Where(station => station.Type == Station.StationType.Intermediate).ToList();

            try
            {
                for (int i = 0; i < ValidStations.Stations.Count(station => station.Type == Station.StationType.Intermediate); i++)
                {
                    intermediateStationCheckboxes[i].Content = intermediateStations[i].Name;
                }//sets checkbox labels to intermediate stations
            }
            catch (Exception) when (intermediateStations.Count != intermediateStationCheckboxes.Count)
            {
                Console.WriteLine("Number of checkboxes needs to be the same as intermediate stations, please amend");
                throw;
            }

            ddType.ItemsSource = Enum.GetNames(typeof(Train.TrainType));
            ddOriginStation.ItemsSource = ValidStations.Stations.Where(station => station.Type == Station.StationType.Endpoint).Select(station => station.Name).ToList(); ;
            ddDestinationStation.ItemsSource = ValidStations.Stations.Where(station => station.Type == Station.StationType.Endpoint).Select(station => station.Name).ToList(); ;
        }

        /// <summary>Selects first element of combobox on load</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null) comboBox.SelectedIndex = 0;
        }

        //Toggles inputs according to train type selected
        private void ddType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                var selectedType = Enum.GetNames(typeof(Train.TrainType))[comboBox.SelectedIndex];

                ToggleInputs(selectedType);
            }
        }

        /// <summary>
        /// Toggles the express inputs.
        /// </summary>
        private void ToggleInputs(string selectedType)
        {
            var intermediateStationInputs = allWindowElements.Cast<FrameworkElement>().Where(element => (string)element.Tag == "IntermediateStations").ToList(); //selects Intermediate Station checkboxes

            switch (selectedType)
            {
                case "Express":
                ToggleElementsEnabled(intermediateStationInputs, false);
                ClearCheckboxesWithTag("IntermediateStations");
                return;
                case "Stopping":
                ToggleElementsEnabled(intermediateStationInputs, true);
                return;
                case "Sleeper":
                ToggleElementsEnabled(intermediateStationInputs, true);
                return;
                default:
                return;
            }
        }

        /// <summary>
        /// Toggles whether the elements are enabled.
        /// </summary>
        /// <param name="elements">The elements.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        private void ToggleElementsEnabled(List<FrameworkElement> elements, bool enable)
        {
            foreach (var element in elements)
            {
                if (enable)
                {
                    element.IsEnabled = true;
                    element.Opacity = 1;
                }
                else
                {
                    element.IsEnabled = false;
                    element.Opacity = .5;
                }
            }
        }

        private void ClearCheckboxesWithTag(string tag)
        {
            var checkboxesToClear = allWindowElements.OfType<CheckBox>().Where(input => (string)input.Tag == tag); //selects checkboxes to clear

            foreach (var checkbox in checkboxesToClear)
            {
                checkbox.IsChecked = false;
            }
        }

        private void btnAddTrain_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var trainFactory = new TrainFactory();
                var newTrain = trainFactory.CreateTrain(GetNewTrainInfo());
                dataFacade.AddTrain(newTrain);
                dataFacade.SaveTrains();
                MessageBox.Show($"Train {newTrain.ID} added!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private TrainInfoHolder GetNewTrainInfo()
        {
            var type = (Train.TrainType)Enum.Parse(typeof(Train.TrainType), ddType.SelectedValue.ToString());

            var newTrainInfoStub = new TrainInfoHolder
            {
                Type = type,
                DepartureDateTime = datetimepickerDepartureTime.Value ?? DateTime.Today,
                OriginStation = ValidStations.Stations.First(station => station.Name == ddOriginStation.SelectedValue.ToString()),
                DestinationStation = ValidStations.Stations.First(station => station.Name == ddDestinationStation.SelectedValue.ToString()),
                IntermediateStations = GetSelectedIntermediateStations(),
                OffersFirstClass = cbFirstClass.IsChecked ?? false
            };
            return newTrainInfoStub;
        }

        private List<Station> GetSelectedIntermediateStations()
        {
            var selectedIntermediateStations = new List<Station>();
            for (var i = 0; i < intermediateStationCheckboxes.Count; i++)
            {
                if (intermediateStationCheckboxes[i].IsChecked ?? false)
                {
                    selectedIntermediateStations.Add(intermediateStations[i]);
                }
            }

            return selectedIntermediateStations;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
