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
using Microsoft.VisualBasic;
using BusinessObjects;
using DataLayer;

namespace Presentation
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

        private Module myModule = new Module();//Hold a reference to the module (Business layer) that is curently being presented
        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
          //Create a new module 
           myModule = new Module();
           update();
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           //Save the existing module to the DataLayer
            try
            {
                myModule.code = Int32.Parse(txtCode.Text);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myModule.name = txtName.Text;

            //Get access to the datalayer
            DataFacadeSingleton df = DataFacadeSingleton.getInstance();
            //Save the module
            df.addModule(myModule);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
            //Find a module & display it
        {
            DataFacadeSingleton df = DataFacadeSingleton.getInstance();//Get access to te the data layer
            myModule = df.getModule(Int32.Parse(txtCode.Text));//find module
            if (myModule != null)//if module found
                update();//display details
        }


        //Update the controls to match the properties of myModule
        private void update()
        {
            txtCode.Text = "" + myModule.code;
            txtName.Text = myModule.name;
            txtStudents.Text = myModule.classList;
        }

        private void btnAddStudentOK_Click(object sender, RoutedEventArgs e)
        {
            //Add a Student to the class list
            //Note - no validation in this example
            try
            {
                int matric = Int32.Parse(txtMatric.Text);
                String name = txtStudentName.Text;
                myModule.addStudent(matric, name);
                this.update();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }


    }
}
