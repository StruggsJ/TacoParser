using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    public class TacoBell : ITrackable //Make the class conform to the ITrackable interface to share fields
    {
        public string Name { get; set; }
        public Point Location { get; set; }



        // You'll need to create a TacoBell class
        // that conforms to ITrackable


        // Your going to need to parse your string as a `double`
        // which is similar to parsing a string as an `int`
        // Then, you'll need an instance of the TacoBell class
        // With the name and point set correctly

        //-- parse values = set parameters to listed things in a method.

        


        //Default constuctor, must have if defining custom constructor -- (according to vid, is there just in case)
        public TacoBell() 
        {
            
        }

        public TacoBell(string name, double latitude, double longitude) // Should this return something or will be retrieved via another method (in nested for loop?) 
        {
            Name = name;
            Location = new Point(latitude, longitude); //Create a constructor in the point class with these two params.
        }
    }
}
