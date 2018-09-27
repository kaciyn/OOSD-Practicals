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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace TimerExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*
     * Timer example, this sets up a very crude reminder system.
     * 
     * Enter a message and a timeout into the form.
     * 
     * A timer object is used to show a message box containing the reminder after the specified time has elapsed
     * 
     */
    public partial class MainWindow : Window
    {
        private Timer myTimer; //Used to ensure the message is shown after the specified time.
        private String reminder; //Message to be displayed

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int secs = Convert.ToInt32(txtCountDown.Text); //Get secs from text box
            reminder = txtMessage.Text; 
            myTimer = new Timer(secs*1000); //Secs to msecs
            myTimer.Elapsed += new ElapsedEventHandler(showReminderHandler);//Set event to be fired after time has elapsed
            myTimer.Enabled = true; //Start timer
            this.WindowState = WindowState.Minimized; //Minimise this window

        }

        //Event handler for the timer control
        private void showReminderHandler(object sender, ElapsedEventArgs e)
        {
            MessageBox.Show("Reminder: "+reminder); // Add date on each timer event
            myTimer.Enabled = false;
            
        }
    }
}
