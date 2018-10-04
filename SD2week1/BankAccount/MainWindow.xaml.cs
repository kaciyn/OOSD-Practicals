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

namespace BankAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBalance.Text = "0";
        }

        private double balance = 0;

        private void btnCredit_Click(object sender, RoutedEventArgs e)
        {
            var amount = Convert.ToDouble(txtAmount.Text);
            if (balance + amount < 0)
            {
                MessageBox.Show("You're not allowed to bankrupt yourself!");
            }
            else
            {
                balance = balance + amount;
                lstHistory.Items.Add($"£{amount} deposited, balance = £{balance}");
            }
            txtBalance.Text = balance.ToString();
        }

        private void btnDebit_Click(object sender, RoutedEventArgs e)
        {
            var amount = Convert.ToDouble(txtAmount.Text);
            if (balance - amount < 0)
            {
                MessageBox.Show("You're not allowed to bankrupt yourself!");
            }
            else
            {
                balance = balance - amount;
                lstHistory.Items.Add($"£{amount} deposited, balance = £{balance}");
            }
            txtBalance.Text = balance.ToString();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
