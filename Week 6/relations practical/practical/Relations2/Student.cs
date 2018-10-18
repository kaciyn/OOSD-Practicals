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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        public string name
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        public string matric
        {
            get
            {
                return txtMatric.Text;
            }
            set
            {
                txtMatric.Text = value;
            }
        }

        public string course
        {
            get
            {
                return txtCourse.Text;
            }
            set
            {
                txtCourse.Text = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
