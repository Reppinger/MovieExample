using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExample
{
    public class Customer
    {
        private string name;
        private List<Rental> rentals = new List<Rental>();

        public Customer(String inName)
        {
            name = inName;
        }

        public String Name
        {
            get
            {
                return name;
            }
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Statement()
        {
            var statementBuilder = new StatementBuilder();
            return statementBuilder.Statement(this.name, this.rentals);
        }
    }
}
