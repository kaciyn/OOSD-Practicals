using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for AllCustomersWindow.xaml
    /// Author: Kaci
    /// Modified: 2018/10/29
    /// </summary>
    public partial class AllCustomersWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllCustomersWindow"/> class & populates customer id listbox with ids in current MailingList instance.
        /// </summary>
        /// <param name="store">The store.</param>
        public AllCustomersWindow(MailingList store)
        {
            InitializeComponent();
            
            lstviewReminders.ItemsSource = GetAllCustomers(store);
        }

        /// <summary>
        /// Gets list of all customers in store.
        /// </summary>
        /// <param name="store">The store.</param>
        /// <returns></returns>
        private List<Customer> GetAllCustomers(MailingList store)
        {
            return store.IDs.Select(store.Find).ToList();
        }

        /// <summary>
        /// Closes window on click
        /// </summary>
        private void btnDismiss_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
