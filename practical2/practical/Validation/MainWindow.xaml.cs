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

namespace Validation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int age = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            //Convert age to numberic
            
            try
            {
                age = Convert.ToInt32(txtAge.Text);
            }catch
            {
                MessageBox.Show("Age must be a number");
                age = 0;
            }

            //Validate name - should be not ""

            try
            {
                if (txtName.Text == "")
                {
                    throw new System.ArgumentException("Field cannot be blank", "Name");
                }
               
                if ((age <18) || (age > 65))
                {
                    throw new System.ArgumentException("Age must be in the range 18 to 65", "Age");
                }

                MessageBox.Show("Validated succesfully");

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
