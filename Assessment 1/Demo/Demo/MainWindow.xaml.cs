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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessObjects;

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Author: Kaci
    /// Modified: 2018/10/14
    /// </summary>
    public partial class MainWindow : Window
    {
        private MailingList store = new MailingList();//a mailing list of customers
        private UIElementCollection allWindowElements;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            var windowPanel = (Panel)Content; //gets contents of MainWindow
            allWindowElements = windowPanel.Children; //gets all UI elements in window

            store.Add(new Customer { ID = 10001, Name = "Kaci", Surname = "Yanova", Email = "sldjfk@slksldkfj.com", SkypeID = "sdkljf234", Phone = "239847293", PreferredContact = "email" }); //default customer for testing so I don't have to enter a new customer every time 
        }

        /// <summary>
        /// Adds new customer from add new customer form textboxes on click
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            var newCustomer = new Customer();
            try
            {
                newCustomer = GetNewCustomerInfo();
                store.Add(newCustomer);
                ClearAddNewCustomerForm();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Searches for customer by id in textbox and either displays customer info in textboxes or deletes customer on click depending on sender button
        /// </summary>
        private void btnSearchOrDeleteByID_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSearchID)
            {
                var idValidationResult = ValidateID(txtSearchID);

                if (idValidationResult.isValid)
                {
                    FindAndDisplayCustomer(idValidationResult.customerID);
                }
                ClearTextbox(txtSearchID);
            }
            else if (sender == btnDelete)
            {
                var idValidationResult = ValidateID(txtDelete);
                if (idValidationResult.isValid)
                {
                    DeleteCustomer(idValidationResult.customerID);
                }
                ClearTextbox(txtDelete);
            }
        }

        /// <summary>
        /// Opens a window containing all customer info in a new window on click
        /// </summary>
        private void btnListAllCustomers_Click(object sender, RoutedEventArgs e)
        {
            var allCustomersWindow = new AllCustomersWindow(store);
            allCustomersWindow.Show();
        }


        /// <summary>
        /// Clears the textbox.
        /// </summary>
        /// <param name="textbox">The textbox.</param>
        static void ClearTextbox(TextBox textbox)
        {
            textbox.Text = "";
        }


        /// <summary>
        /// Gets the new customer information from the ad new customer form textboxes.
        /// </summary>
        /// <returns></returns>
        private Customer GetNewCustomerInfo()
        {
            var customer = new Customer
            {
                ID = GenerateNewCustomerID(),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                SkypeID = txtSkype.Text,
                Phone = txtPhone.Text,
                PreferredContact = txtPreferredContact.Text
            };

            return customer;
        }

        /// <summary>
        /// Clears the add new customer form textboxes.
        /// </summary>
        private void ClearAddNewCustomerForm()
        {
            var addNewFormTextboxes = allWindowElements.OfType<TextBox>().Where(textbox => (string)textbox.Tag == "AddNewForm"); //selects Add New Customer form textboxes

            foreach (var textbox in addNewFormTextboxes)
            {
                ClearTextbox(textbox);
            }
        }

        /// <summary>
        /// Generates new customer ID, incrementing from the highest stored ID by one up to 50000.
        /// </summary>
        /// <exception cref="Exception">Customers have reached capacity, cannot add ID higher than 50000</exception>
        private int GenerateNewCustomerID()
        {
            var existingCustomerIDs = store.IDs;

            var mostRecentCustomerID = existingCustomerIDs.Count < 1 ? 10000 : existingCustomerIDs.Last();

            if (mostRecentCustomerID >= 50000)
            {
                throw new Exception("Customers have reached capacity, cannot add ID higher than 50000");
            }

            return mostRecentCustomerID + 1;
        }


        /// <summary>
        /// Checks whether id is valid and returns id parsed to int (if possible) and whether the entered id is valid
        /// </summary>
        /// <param name="idTextBox">The identifier text box.</param>
        /// <returns></returns>
        private (bool isValid, int customerID) ValidateID(TextBox idTextBox)
        {
            var isValidID = int.TryParse(idTextBox.Text, out int customerID) && customerID <= 50000 && customerID > 10000;

            if (!isValidID)
            {
                MessageBox.Show("ID cannot contain non-numeric characters and must be between 10001 and 50000");
            }

            return (isValidID, customerID);
        }

        /// <summary>
        /// Finds customer from ID and displays information in textboxes.
        /// </summary>
        /// <param name="customerID">The customer identifier.</param>
        private void FindAndDisplayCustomer(int customerID)
        {
            var foundCustomer = store.Find(customerID);
            if (foundCustomer == null)
            {
                MessageBox.Show("No customer with entered ID found");
            }
            else
            {
                DisplayCustomerInfo(foundCustomer);
            }
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
            txtPreferredContactDisplay.Text = customer.GetPreferredContact();
        }

        /// <summary>
        /// Deletes the customer by ID if such a customer exists.
        /// </summary>
        /// <param name="customerID">The customer identifier.</param>
        private void DeleteCustomer(int customerID)
        {
            var foundCustomer = store.Find(customerID);
            if (foundCustomer == null)
            {
                MessageBox.Show("No customer with entered ID found");
            }
            else
            {
                store.Delete(customerID);
                MessageBox.Show($"Customer with ID {customerID} deleted.");
            }
        }
    }
}
