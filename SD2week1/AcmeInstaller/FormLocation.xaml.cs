using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AcmeInstaller
{
    /// <summary>
    /// Interaction logic for FormLocation.xaml
    /// </summary>
    public partial class FormLocation : Window
    {
        public FormLocation()
        {
            InitializeComponent();

            var locationList = "Scotland,England,Ireland,Wales,France".Split(',');
            foreach (var location in locationList)
            {
                lstLocations.Items.Add(location);
            }
        }
        public string selectedLocation;

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedLocation = lstLocations.SelectedValue;
        }

        private void btnPrevious_btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnNext)
            {
                FormEnd formEnd = new FormEnd();
                formEnd.Show();
                Close();
            }
            if (sender == btnPrevious)
            {
                MainWindow formStart = new MainWindow();
                formStart.Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
