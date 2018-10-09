using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SE_Lab4.Models
{
    public class Dashboard
    {

        public int AddedPersons;
        public IIdentity id ;
        public List<Person> Birthday_People = new List<Person>();
        public List<Person> Updated_People = new List<Person>();

        private static Dashboard instance = new Dashboard();
        private Dashboard() { }
        public static Dashboard GetInstance()
        {
            return instance;
        }

    }
}