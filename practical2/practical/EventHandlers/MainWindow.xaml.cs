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

namespace EventHandlers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            txtMyText.Background = Brushes.Red;
        }

        private void txtMyText_MouseLeave(object sender, MouseEventArgs e)
        {
            txtMyText.Background = Brushes.Green;
        }

        private void btnStopEvents_Click(object sender, RoutedEventArgs e)
        {
            txtMyText.MouseEnter -= TextBox_MouseEnter;
            txtMyText.MouseLeave -= txtMyText_MouseLeave;
        }

        private void btnStartEvents_Click(object sender, RoutedEventArgs e)
        {
            txtMyText.MouseEnter += TextBox_MouseEnter;
            txtMyText.MouseLeave += txtMyText_MouseLeave;
        }

        
      

       
    }
}
