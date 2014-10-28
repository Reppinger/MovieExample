using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExample
{
    public class Movie    
    { 
        public const int CHILDRENS = 2; 
        public const int REGULAR = 0; 
        public const int NEW_RELEASE = 1; 

        private String title; 
        private int priceCode; 
        public Movie ( string inTitle, int inPriceCode) { 
            title = inTitle; 
            priceCode = inPriceCode; 
        } 
        public int PriceCode {
            set{
                priceCode = value;
            }
            get {
                return priceCode;
            }
        }
        public String Title 
        {
            get
            {
                return title;
            }
        }
    }
}
