using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Module
        /*
         * Represents a module, with a list of enroled Student objects
         * 
         * Note no validation in this example
         */
    {
        private String _name;
        private int _code;

        private List<Student> students = new List<Student>();//Enroled students
        public int code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public String name
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
        //Add a student to the module
        public void addStudent(int matric, String name){
            students.Add(new Student(matric, name));
        }

        //Class list returns a formatted list of enroled Students
        public String classList
        {
            get
            {
                String list = "";
                foreach (Student s in students){
                    list=list + s.matric + " : " + s.name + "\n";
                }
                return list;
            }
        }
        
    }
}
