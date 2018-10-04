using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReminderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Reminders.ReminderCollection = new ObservableCollection<Reminder>();
            lstviewReminders.ItemsSource = Reminders.ReminderCollection;

            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += CheckIfShouldShowReminder;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();

            Reminders.ReminderCollection.CollectionChanged += (s, e) =>
            {
                lstviewReminders.UpdateLayout();
            };
        }

        private void btnNewReminder_Click(object sender, RoutedEventArgs e)
        {
            CreateNew createNew = new CreateNew();

            createNew.Show();
        }

        private void CheckIfShouldShowReminder(object sender, EventArgs e)
        {
            var reminderIndex = 0;
            foreach (var reminder in Reminders.ReminderCollection)
            {
                if (reminder.TimeEntered.AddSeconds(reminder.DelaySeconds) <= DateTime.Now && !reminder.HasBeenTriggered)
                {
                    var reminderPopup = new ReminderPopup(reminder);
                    Reminders.ReminderCollection[reminderIndex].HasBeenTriggered = true;
                    reminderPopup.Show();
                }
                reminderIndex++;
            }
        }
    }
}