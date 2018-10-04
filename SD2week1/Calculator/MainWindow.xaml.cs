using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Reset();
        }

        private int? heldNumber;
        private string pendingOperation;
        private bool operatorButtonsDisabled;
        private bool equalsButtonDisabled;
        private bool newCalculationIsNext;

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var buttonContent = button.Content.ToString();

            if (newCalculationIsNext)
            {
                Reset();
                newCalculationIsNext = false;
            }

            switch (button.Tag.ToString())
            {
                case "Clear":
                    Reset();
                    break;

                case "Digit":
                    txtInput.Text = txtInput.Text + buttonContent;

                    if (operatorButtonsDisabled)
                    {
                        ToggleButtons("Operator");
                    }
                    break;

                case "Operator":
                    HandleOperatorButton(buttonContent);
                    break;

                case "Equals":
                    Calculate();
                    break;

                default:
                    MessageBox.Show("Unknown button pressed");
                    break;
            }

        }

        private void HandleOperatorButton(string buttonContent)
        {
            heldNumber = int.Parse(txtInput.Text);
            pendingOperation = buttonContent;
            txtInput.Text = "";
            ToggleButtons("Equals");
        }

        private void Reset()
        {
            heldNumber = null;
            pendingOperation = null;
            txtInput.Text = "";

            if (!operatorButtonsDisabled)
            {
                ToggleButtons("Operator");
            }

            if (!equalsButtonDisabled)
            {
                ToggleButtons("Equals");
            }
        }

        private void Calculate()
        {
            var dataTable = new DataTable();

            var secondNumber = txtInput.Text;
            var requestedCalculationString = heldNumber + pendingOperation + secondNumber;

            try
            {
                var result = dataTable.Compute(requestedCalculationString, "");
                txtInput.Text = result.ToString();
            }
            catch (Exception nullOperator) when (pendingOperation == null)
            {
                MessageBox.Show("ERR: Operator cannot be null, please try again");
                Reset();
            }
            newCalculationIsNext = true;

        }

        private void ToggleButtons(string buttonTag)
        {
            Panel windowPanel = (Panel)Content;

            UIElementCollection windowElements = windowPanel.Children;

            var buttonList = windowElements.OfType<Button>();

            foreach (var button in buttonList.Where(b => b.Tag.ToString() == buttonTag))
            {
                button.IsEnabled = !button.IsEnabled;
            }

            if (buttonTag == "Operator")
            {
                operatorButtonsDisabled = !operatorButtonsDisabled;
            }
            else if (buttonTag == "Equals")
            {
                equalsButtonDisabled = !equalsButtonDisabled;
            }
        }
    }
}

