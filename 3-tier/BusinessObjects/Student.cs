using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    /*
     * Represents and enroled Student
     * Note - no validation in this example
     */ 
    class Student
    {
        private int _matricNumber;
        private String _name;

        public Student(int matric, String name)
        {
            _matricNumber = matric;
            _name = name;
        }
        public int matric //Matric number
        {
            get
            {
                return _matricNumber;
            }

            set
            {
                _matricNumber = value;
            }
        }

        public String name //Student name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
    }
}
