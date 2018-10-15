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
    /// Modified: 2018/10/15S
    /// </summary>
    public partial class AllCustomersWindow : Window
    {
        /// <summary>
        /// Copy of the current mailing list instance
        /// </summary>
        private MailingList customers;
        private bool AdvancedContactsVisible;//only relevant for the extra contact fields, see comment on line 79
        /// <summary>
        /// Initializes a new instance of the <see cref="AllCustomersWindow"/> class & populates customer id listbox with ids in current MailingList instance.
        /// </summary>
        /// <param name="store">The store.</param>
        public AllCustomersWindow(MailingList store)
        {
            InitializeComponent();
            customers = store;
            lstboxCustomerIDs.ItemsSource = customers.IDs;
        }

        /// <summary>
        /// Closes window on click
        /// </summary>
        private void btnDismiss_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Finds and displays selected customer info from listbox in textboxes
        /// </summary>
        private void lstboxCustomerIDs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = customers.Find((int)lstboxCustomerIDs.SelectedItem);
            DisplayCustomerInfo(selectedCustomer);
        }

        /// <summary>
        /// Displays the customer information in textboxes
        /// </summary>
        /// <param name="customer">The customer.</param>
        private void DisplayCustomerInfo(Customer customer)
        {
            txtIDDisplay.Text = customer.ID.ToString();
            txtNameDisplay.Text = customer.Name;
            txtSurnameDisplay.Text = customer.Surname;
            txtEmailDisplay.Text = customer.Email;
            txtSkypeDisplay.Text = customer.SkypeID;
            txtPhoneDisplay.Text = customer.Phone;
            txtPreferredContactDisplay.Text = customer.PreferredContact;


            //some extra preferred contact field work I'm not sure is wanted, see comment on line 79
            var preferredContactFull = customer.GetPreferredContact();
            txtPreferredContactDisplayAdvanced.Text = preferredContactFull;
            lblPreferredContactSpecificAdvanced.Text = preferredContactFull.Split(':').First().Trim();
            txtPreferredContactAdvanced.Text = preferredContactFull.Split(':').Last().Trim();
        }

        //Methods below aren't really part of the assignment but they do account for some of the ambiguity in the assignment in case I didn't interpret what exactly the preferred contact field is supposed to display, as well as a field displaying the specific contact of the customer, which was implemented because it "would be neat"
        //The fields and button to show them have their opacity set to zero by default so it doesn't clutter up the UI
        
        /// <summary>
        /// Sets show advanced button opacity to 100% on hover
        /// </summary>
        private void btnShowAdvanced_OnMouseEnter(object sender, MouseEventArgs e)
        {
            btnShowAdvanced.Opacity = 100;
        }

        /// <summary>
        /// Sets show advanced button opacity to 100% on hover
        /// </summary>
       private void btnShowAdvanced_OnMouseLeave(object sender, MouseEventArgs e)
        {
            btnShowAdvanced.Opacity = 0;
        }

        /// <summary>
        /// Calls ToggleAdvancedContacts() on click
        /// </summary>
        private void btnShowAdvanced_Click(object sender, RoutedEventArgs e)
        {
            ToggleAdvancedContacts();
        }

        /// <summary>
        /// Toggles the opacity of the advanced contacts fields.
        /// </summary>
        private void ToggleAdvancedContacts()
        {
            if (AdvancedContactsVisible)
            {
                lblPreferredContactSpecificAdvanced.Opacity = 0;
                lblPreferredContactAdvanced.Opacity = 0;
                txtPreferredContactAdvanced.Opacity = 0;
                lblPreferredContactSpecificAdvanced.Opacity = 0;
                txtPreferredContactDisplayAdvanced.Opacity = 0;
            }
            else
            {
                lblPreferredContactSpecificAdvanced.Opacity = 100;
                lblPreferredContactAdvanced.Opacity = 100;
                txtPreferredContactAdvanced.Opacity = 100;
                lblPreferredContactSpecificAdvanced.Opacity = 100;
                txtPreferredContactDisplayAdvanced.Opacity = 100;
            }
            AdvancedContactsVisible = !AdvancedContactsVisible;
        }
    }
}
