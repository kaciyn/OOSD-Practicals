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
    /// Interaction logic for AddBooking.xaml
    /// </summary>
    public partial class AddBooking : Window
    {

        private UIElementCollection allWindowElements;

        readonly DataFacade.DataFacadeSingleton dataFacade = DataFacade.DataFacadeSingleton.GetInstance();

        public AddBooking()
        {
            InitializeComponent();

            var windowPanel = (Panel)Content; //gets contents of MainWindow
            allWindowElements = windowPanel.Children; //gets all UI elements in window


            ddTrain.ItemsSource = dataFacade.GetAllTrains().Select(train => train.ID).ToList();
            ddDeparture.ItemsSource = ValidStations.Stations.Select(station => station.Name).ToList();
            ddDestination.ItemsSource = ValidStations.Stations.Select(station => station.Name).ToList();

            var coachRange = Enumerable.Range('A', 'H' - 'A' + 1).Select(c => (char)c).ToList();
            ddCoach.ItemsSource = coachRange;

            ddSeat.ItemsSource = Enumerable.Range(1, 60);

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
        private void ddTrain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                var selectedType = dataFacade.GetTrain(comboBox.SelectedValue.ToString());

                ToggleInputs(selectedType);
            }
        }

        /// <summary>
        /// Toggles the express inputs.
        /// </summary>
        private void ToggleInputs(Train selectedTrain)
        {
            ToggleElementsEnabled(allWindowElements.Cast<FrameworkElement>().ToList(),
                true); //resets all controls to enabled


            FilterStations(selectedTrain);

            var elementsToDisable = new List<FrameworkElement>();

            if (!selectedTrain.OffersFirstClass)
            {
                elementsToDisable.Add(cbFirstClass);
            }

            if (selectedTrain.Type != Train.TrainType.Sleeper)
            {
                elementsToDisable.Add(cbCabin);
            }

            ToggleElementsEnabled(elementsToDisable, false);
        }

        private void FilterStations(Train selectedTrain)
        {
            var o= selectedTrain.IntermediateStations.Append(selectedTrain.OriginStation).Select(station => station.Name).ToList();
            var t= selectedTrain.IntermediateStations.Append(selectedTrain.DestinationStation).Select(station => station.Name).ToList();

            ddDeparture.ItemsSource = selectedTrain.IntermediateStations.Append(selectedTrain.OriginStation).Select(station => station.Name).ToList();

            ddDestination.ItemsSource = selectedTrain.IntermediateStations.Append(selectedTrain.DestinationStation).Select(station => station.Name).ToList();
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

                    //unchecks checkboxes on disable
                    if ((string)element.Tag == "CheckBox")
                    {
                        var checkbox = (CheckBox)element;
                        checkbox.IsChecked = false;
                    }
                }
            }
        }

        private void cbCabin_Toggled(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            if (checkbox.IsChecked ?? false)
            {
                ToggleElementsEnabled(new List<FrameworkElement> { ddSeat }, false);
            }
            else
            {
                ToggleElementsEnabled(new List<FrameworkElement> { ddSeat }, true);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newBooking = GetNewBooking();
                dataFacade.AddBooking(newBooking);
                dataFacade.SaveBookings();
                MessageBox.Show($"Booking for {newBooking.Name} on train {newBooking.TrainID} added! The total fare is: £{Fare.CalculateFare(newBooking, dataFacade.GetTrain(newBooking.TrainID).Type)}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private Booking GetNewBooking()
        {
            var newBooking = new Booking
            {
                Name = txtName.Text,
                TrainID = ddTrain.Text,
                DepartureStation = ValidStations.Stations.First(station => station.Name == ddDeparture.SelectedItem.ToString()),
                DestinationStation = ValidStations.Stations.First(station => station.Name == ddDestination.SelectedItem.ToString()),
                FirstClass = cbFirstClass.IsChecked ?? false,
                Cabin = cbCabin.IsChecked ?? false,
                Coach = ddCoach.Text,
                Seat = cbCabin.IsChecked ?? false
                    ? 0
                    : int.Parse(ddSeat
                        .Text) //if the passenger selects a cabin, sets seat to 0 since there's no seat allocations in a cabin I'm assuming
            };
            return newBooking;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        }
}