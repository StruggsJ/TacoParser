using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            //From video: create a MeterToMiles constant double for covertion.

            const double MetersToMiles = 0.00062137;

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------





            //* ToDo:  Input debug log logging varables being created.



            // TODO: Create two `ITrackable` variables with initial values of `null` (x).
            // These will be used to store your two taco bells that are the farthest from each other.

            // instead of finalDistance /testDistance, this is defined as location1 (testDistance) and location2 (finalDistance)
            // above is wrong, finalDistance/testDistant are double values (locationDistance1 /locationDistance2)


            //renamed location1/location2 to more descriptive names (tacoBell1/tacoBell2)
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            
            //Insert debug log here "class ITrackable location created"

            //// Create a `double` variable to store the distance (x)
            /// renamed this to finalDistance and test Distance to follow tutorial video better

            double testDistance = 0;
            double finalDistance = 0;

            //Debug Log: Double varables created.

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`  (x) -- Already done


            //NESTED LOOPS SECTION ToDo List(Location A = locA ; Location B = locB)
            // !!Reminder: Do not forget to add debug logs!!
            //Note: Use GetDistanceTo() from using GeoCoordinatePortable;


            // 1.Create a new corA Coordinate with your locA's lat and long
            // 2. Do a loop for your locations to grab each location as the origin (perhaps: `locA`) - locA i
            // 3. Do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // 4. Create a new Coordinate with your locB's lat and long
            // 5. Compare the two using `.GetDistanceTo()`, which returns a double
            // 5a. If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above.
            // 6.  Once you've looped through everything, you've found the two Taco Bells farthest away from each other

            //1.Create a new corA Coordinate with your locA's lat and long
            //

            //Changed variable name from latitudeA/longitudeA to geo1 and geo2 -- latitude and longitude is found in each varable as fields within the object; not separate.

            GeoCoordinate geo1 = new GeoCoordinate();
            GeoCoordinate geo2 = new GeoCoordinate();

            //2. Do a loop for your locations to grab each location as the origin (perhaps: `locA`) - locA i

            // Possible Logic:

            // 1. Go through the list (csv file), selecting the first farest location
            // 2. Then select the second location.
            // 3. Calculate distance from the two
            // 4. Compare distance, store in var.
            // 5. Repeat process for another location, store in 


            //1. Go through the list (csv file), selecting the first farest location.

            // An array varable is created here, parsing from the Parser class using Linq (.Select/.ToArray) /from vid

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
          
            ITrackable[] locations = lines.Select(parser.Parse).ToArray(); //Why will there be an error when replacing var with ITrackable (Hint: Do not forget the [] when using Linq methods)

            //Actual Code from video /w annotations

            // According to vid, might be a faster method; account for finding the farest location eariler without going through rest of data.

            for (int i = 0; i < locations.Length; i++) //Setting up the condition using length of the locations varable - First location
            {
                geo1.Latitude = locations[i].Location.Latitude;
                geo1.Longitude= locations[i].Location.Longitude;

                for (int j = 1; j < locations.Length; j++) // Second location
                {
                    geo2.Latitude = locations[j].Location.Latitude;
                    geo2.Longitude = locations[j].Location.Longitude;

                    

                    testDistance = geo1.GetDistanceTo(geo2); //Retriving the distance between the two after getting the first one from the first for loop (starting at index zero)

                  if(finalDistance < testDistance)
                   {

                        //assigning varables if test conditon (If the final distance is less than the test distance)

                      finalDistance = testDistance; // Set the final distance to the test distance, setting up for the next location (first location)
                        tacoBell1 = locations[i];  // assigning locations from both locations retrieved from the index position
                        tacoBell2 = locations[j];
                   }

                }
            }

            //define meter to miles varable to multiply to distance (second line)
            Console.WriteLine($"The two furthest {tacoBell1.GetType().Name}'s are {tacoBell1.Name} and {tacoBell2.Name}.");
            Console.WriteLine($"The total distance is {Math.Round((finalDistance * MetersToMiles), 2)} miles.");
        }
    }
}
