using System;
using System.Collections.Generic;

namespace MovieExample
{
    public class StatementBuilder
    {

        public string Statement(string customerName, List<Rental> customerRentals)
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            String result = "Rental Record for " + customerName + "\n";
            foreach (var rental in customerRentals)
            {
                double thisAmount = 0;
                // determine amounts for each line 
                switch (rental.TheMovie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.CHILDRENS:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                }

                // add frequent renter points 
                frequentRenterPoints++;

                // add bonus for a two day new release rental 
                if ((rental.TheMovie.PriceCode == Movie.NEW_RELEASE) && rental.DaysRented > 1)
                    frequentRenterPoints++;

                // show figures for this rental 
                result += "\t" + rental.TheMovie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;

            }

            // add footer lines 
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }
    }
}