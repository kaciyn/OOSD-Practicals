using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusinessObjects
{
    /// <summary>
    /// Contains properties and validation for the Customer class, as well as a method for returning their preferred contact
    /// Author: Kaci
    /// Modified: 2018/10/14
    /// </summary>
    public class Customer
    {
        private int _customerID;
        /// <summary>
        /// Gets or sets the customer id, valid between 10001 and 50000.
        /// </summary>
        /// <value>
        /// The customer id.
        /// </value>
        /// <exception cref="ArgumentException">ID must be between 10001 and 50000</exception>
        public int ID
        {
            get => _customerID;
            set
            {
                if (value < 10001 || value > 50000)
                {
                    throw new ArgumentException("ID must be between 10001 and 50000");
                }
                _customerID = value;
            }
        }

        private string _name;
        /// <summary>
        /// Gets or sets the customer name, cannot be blank.
        /// </summary>
        /// <value>
        /// The customer name.
        /// </value>
        /// <exception cref="ArgumentException">Name cannot be empty</exception>
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length<1)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                _name = value;
            }
        }

        private string _surname;
        /// <summary>
        /// Gets or sets the customer surname, cannot be blank.
        /// </summary>
        /// <value>
        /// The customer surname.
        /// </value>
        /// <exception cref="ArgumentException">Surname cannot be empty</exception>
        public string Surname
        {
            get => _surname;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Surname cannot be empty");
                }
                _surname = value;
            }
        }

        private string _email;
        /// <summary>
        /// Gets or sets the customer email, must contain "@".
        /// </summary>
        /// <value>
        /// The customer email.
        /// </value>
        /// <exception cref="ArgumentException">Value entered not a valid email</exception>
        public string Email
        {
            get => _email;
            set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Value entered not a valid email; must contain \"@\"");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Gets or sets the customer skype ID.
        /// </summary>
        /// <value>
        /// The skype identifier.
        /// </value>
        public string SkypeID { get; set; }

        private string _phone;
        /// <summary>
        /// Gets or sets the customer phone, cannot be blank.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        /// <exception cref="ArgumentException">Phone cannot be empty</exception>
        public string Phone
        {
            get => _phone;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Phone cannot be empty");
                }
                _phone = value;
            }
        }

        private string _preferredContact;
        /// <summary>
        /// Gets or sets the customer's preferred contact, restricted to email,tel, or skype.
        /// </summary>
        /// <value>
        /// The preferred contact.
        /// </value>
        /// <exception cref="ArgumentException">Contact type not valid, must be: email, tel, or skype</exception>
        public string PreferredContact
        {
            get => _preferredContact;
            set
            {
                if (value != "email" && value != "tel" && value != "skype")
                {
                    throw new ArgumentException("Contact type not valid, must be: email, tel, or skype");
                }
                _preferredContact = value;
            }
        }

        /// <summary>
        /// Returns customer's preferred contact
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Preferred contact type not valid, must be: email, tel, or skype</exception>
        public string GetPreferredContact()
        {
            switch (PreferredContact)
            {
                case "email":
                    return $"Email: {Email}";
                case "tel":
                    return $"Tel: {Phone}";
                case "skype":
                    return $"Skype: {Email}";
                default:
                    throw new Exception("Preferred contact type not valid, must be: email, tel, or skype");
            }
        }
    }
}
