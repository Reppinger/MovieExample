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
                var thisAmount = CalculateRentalPrice(rental);

                frequentRenterPoints = CalculateFrequentRenterPoints(frequentRenterPoints, rental);

                // show figures for this rental 
                result += "\t" + rental.TheMovie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;

            }

            // add footer lines 
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";

            return result;
        }

        private static int CalculateFrequentRenterPoints(int frequentRenterPoints, Rental rental)
        {
            frequentRenterPoints++;

            if (IsEligibleForBonus(rental))
                frequentRenterPoints++;
            return frequentRenterPoints;
        }

        private static bool IsEligibleForBonus(Rental rental)
        {
            return (rental.TheMovie.PriceCode == Movie.NEW_RELEASE) && rental.DaysRented > 1;
        }

        private static double CalculateRentalPrice(Rental rental)
        {
            double thisAmount = 0;
            // determine amounts for each line 
            switch (rental.TheMovie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2)*1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.DaysRented*3;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3)*1.5;
                    break;
            }
            return thisAmount;
        }
    }
}