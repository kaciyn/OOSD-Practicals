using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Relations2
{
    public partial class University : Form
    {
        public University()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student peter = new Student();
            peter.name = "Peter";
            peter.matric = "1234/1";
            peter.course = "Computing";

            peter.Show();
        }
    }
}
