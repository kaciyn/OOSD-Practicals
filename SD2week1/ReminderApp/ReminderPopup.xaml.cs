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
    /// Interaction logic for ReminderPopup.xaml
    /// </summary>
    public partial class ReminderPopup : Window
    {
        public ReminderPopup(Reminder reminder)
        {
            InitializeComponent();
            txtReminder.Text = reminder.ReminderMessage;
        }
        
        private void btnDismiss_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
