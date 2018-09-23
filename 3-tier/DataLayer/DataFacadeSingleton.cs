using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataLayer
{
    /*
     * A Facade for acessing the data layer
     */
    public class DataFacadeSingleton
    {
        //Singelton code
        private static DataFacadeSingleton reference;

        private DataFacadeSingleton() { }

        public static DataFacadeSingleton getInstance()
        {
            if (reference == null)
                reference = new DataFacadeSingleton();

            return reference;
        }
        //Done Singleton code


        private Database db = new Database();//The DB used to persist classes
        
        //Save module to DB
        public void addModule(Module m)
        {
            db.add(m.code, m);

        }

        //Get a Module object based on the supplied module code
        public Module getModule(int code)
        {
            return db.get(code);
        }
    }
}
