using System;
using MovieExample;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class TestCustomer
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void TestStatement1()
        {
            Customer customer = new Customer("Bob");
            
            Movie movie = new Movie("Maleficent", Movie.NEW_RELEASE);
            Rental rental = new Rental(movie, 2);

            customer.AddRental(rental);

            movie = new Movie("Frozen", Movie.CHILDRENS);
            rental = new Rental(movie, 3);

            customer.AddRental(rental);
            string actual = customer.Statement();
            string expected1 = "";
            Assert.AreNotEqual(expected1, actual);

            string expected2 = "Rental Record for Bob\n"+
                                    "\tMaleficent\t6\n"+
                                    "\tFrozen\t1.5\n"+
                               "Amount owed is 7.5\n"+
                               "You earned 3 frequent renter points";
            Assert.AreEqual(expected2, actual);

            Console.Write(actual);
        }

        [TestCase(1, "3")]
        [TestCase(2, "6")]
        public void TestRentalCostByForNewRelease(int rentalDays, string expectedRentalCost)
        {
            var movie = new Movie("", Movie.NEW_RELEASE);
            var rental = new Rental(movie, rentalDays);
            var customer = new Customer("");
            customer.AddRental(rental);
            var statement = customer.Statement();

            StringAssert.Contains(expectedRentalCost, statement);
        }


        [TestCase(1, "2")]
        [TestCase(2, "2")]
        [TestCase(3, "3.5")]
        [TestCase(4, "5")]
        public void TestRentalCostByForRegular(int rentalDays, string expectedRentalCost)
        {
            var movie = new Movie("", Movie.REGULAR);
            var rental = new Rental(movie, rentalDays);
            var customer = new Customer("");
            customer.AddRental(rental);
            var statement = customer.Statement();

            StringAssert.Contains(expectedRentalCost, statement);
        }

        [TestCase(1, "1.5")]
        [TestCase(2, "1.5")]
        [TestCase(3, "1.5")]
        [TestCase(4, "3")]
        [TestCase(5, "4.5")]
        public void TestRentalCostByForChildrens(int rentalDays, string expectedRentalCost)
        {
            var movie = new Movie("", Movie.CHILDRENS);
            var rental = new Rental(movie, rentalDays);
            var customer = new Customer("");
            customer.AddRental(rental);
            var statement = customer.Statement();

            StringAssert.Contains(expectedRentalCost, statement);
        }

        [Test]
        public void TestBasicFrequentRenterPoints()
        {
            var regularMovie = new Movie("", Movie.REGULAR);
            var childrensMovie = new Movie("", Movie.CHILDRENS);
            var customer = new Customer("");
            customer.AddRental(new Rental(regularMovie, 1));
            customer.AddRental(new Rental(childrensMovie, 3));
            var statement = customer.Statement();

            StringAssert.Contains("2 frequent renter points", statement);
        }

        [TestCase(1, 1)]
        [TestCase(2,2)]
        [TestCase(3,2)]
        public void TestBonusFrequentRenterPoints(int rentalDays, int expectedPoints)
        {
            var newReleaseMovie = new Movie("", Movie.NEW_RELEASE);
            var customer = new Customer("");
            customer.AddRental(new Rental(newReleaseMovie, rentalDays));
            var statement = customer.Statement();

            StringAssert.Contains(string.Format("{0} frequent renter points", expectedPoints), statement);
        }

        [Test]
        public void TestTotalAmountOwedSumsCorrectly()
        {
            var regularMovie = new Movie("", Movie.REGULAR);
            var childrensMovie = new Movie("", Movie.CHILDRENS);
            var customer = new Customer("");
            customer.AddRental(new Rental(regularMovie, 1));
            customer.AddRental(new Rental(childrensMovie, 1));
            var statement = customer.Statement();

            StringAssert.Contains("Amount owed is 3.5", statement);
        }


    }
}
