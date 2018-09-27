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
using System.Windows.Shapes;

namespace AcmeInstaller
{
    /// <summary>
    /// Interaction logic for FormEnd.xaml
    /// </summary>
    public partial class FormEnd : Window
    {
        public FormEnd()
        {
            InitializeComponent();

            MainWindow mainWindow;

            txtFinished.Text = $"Thank you {mainWindow.name} for using our software. We know that you live in {}, so don't fuckin test us (-:";
        }


    }
}
