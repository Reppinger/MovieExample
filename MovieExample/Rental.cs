using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExample
{
    public class Rental 
    { 
        private Movie movie; 
        private int daysRented; 
        public Rental(Movie inMovie, int inDaysRented) 
        { 
            movie = inMovie; 
            daysRented = inDaysRented; 
        }
        public int DaysRented
        {
            get
            {
                return daysRented;
            }
        }
        public Movie TheMovie
        {
            get
            {
                return movie;
            }
        }
    }
}
