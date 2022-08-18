using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmutableClass
{
    class Country
    {
        public string Name 
        {
            get { return Name; }
            private set { Name = value; }
        }

        public string Currency
        {
            get { return Currency; }
            private set { Currency = value; }
        }
        public Country(string Name, string Currency) 
        { 
            this.Name = Name;
            this.Currency = Currency;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country("A","B");
            //country.Currency = "C";
        }
    }
}
