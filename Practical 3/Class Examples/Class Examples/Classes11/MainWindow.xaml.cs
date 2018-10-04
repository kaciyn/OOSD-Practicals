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

namespace Classes11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Car myCar;
        //Car object

        public MainWindow()
        {
            InitializeComponent();



        }

        public Car defaultCar = new Car() { Colour = "blue", Cost = 10, Type = "Škoda", Make = "Octavia" };

        private void BtnCreateCar_Click(object sender, RoutedEventArgs e)
        {
            /*
             * 1) Create a new instance of Car
             * e.g.
             *  myCar = new Car();
             *  
             *  
             * 2) Set the make ans colour properties of your car object to the values entered into the text boxes
             *
             * 3) Add text boxes and labels for the other properties of Car so that all the properties may be set
             * 
             * 4) Create a button that clears all of the values entered into the text boxes
             * 
             * 5) Create a button that will change the contents of the text boxes to match the car object properties
             * 
             *
             */
            var car = new Car() { Make = txtMake.Text, Colour = txtColour.Text, Cost = int.Parse(txtCost.Text), Type = txtType.Text };

            Display(car);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtMake.Text = "";
            txtColour.Text = "";
            txtCost.Text = "";
            txtType.Text = "";
        }


        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            txtMake.Text = defaultCar.Make;
            txtColour.Text = defaultCar.Colour;
            txtCost.Text = defaultCar.Cost.ToString();
            txtType.Text = defaultCar.Type;
        }

        public void Display(Car car)
        {
            MessageBox.Show(
                $"The car is a" +
                " " + car.Country +
                " " + car.Make +
                " " + car.Type +
                " " + car.Colour +
                " " + car.Cost
            );
            Console.ReadLine();
        }


    }
}
