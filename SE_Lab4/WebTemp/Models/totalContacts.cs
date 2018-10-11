using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTemp.Models
{
    public class totalContacts
    {
        private int total;
        private Person currsentPerson;

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public Person CurrsentPerson
        {
            get
            {
                return currsentPerson;
            }

            set
            {
                currsentPerson = value;
            }
        }
    }
}