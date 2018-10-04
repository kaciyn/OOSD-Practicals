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

namespace ReminderApp
{
    /// <summary>
    /// Interaction logic for CreateNew.xaml
    /// </summary>
    public partial class CreateNew : Window
    {
        public CreateNew()
        {
            InitializeComponent();
        }

        private Reminder newReminder;

        private void txtReminder_TextChanged(object sender, TextChangedEventArgs e)
        {
            newReminder = new Reminder { ReminderMessage = txtReminder.Text };
        }

        private void btnAddReminder_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtDelay.Text, out var seconds) && seconds > 0)
            {
                newReminder.DelaySeconds = seconds;
                newReminder.TimeEntered = DateTime.Now;
                Reminders.ReminderCollection.Add(newReminder);

                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid time in seconds");
            }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
