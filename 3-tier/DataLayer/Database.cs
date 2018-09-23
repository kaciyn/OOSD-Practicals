using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataLayer
{
    class Database
        //Represents persistence - but doesn't actually persist in this example
    {
        private Dictionary<int, Module> db = new Dictionary<int, Module>();

        public void add(int k, Module val){
            if (db.ContainsKey(k))
            {
                db[k] = val;
            }
            else
            {
                db.Add(k, val);
            }
        }

        public Module get(int val)
        {
            return db[val];
        }

    }
}
