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

            txtFinished.Text = $"Thank you {UserInfo.Name} for using our software. We know that you live in {UserInfo.Location}, so don't fuckin test us (-:";
        }

        private void btnFinished_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
