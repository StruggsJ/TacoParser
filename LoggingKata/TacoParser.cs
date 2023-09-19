namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0,
            // the longitude from your array at index 1,
            //and grab the name for your array at index 2

            // Create varables holding these values.

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];


            //Create the TacoBell Class and uncomment this (from vid)
            // Make the class' method take three params. -- From vid: This is a paramized constructor.

            ITrackable tacoBell = new TacoBell(name, latitude, longitude);

            // Return the instance of your TacoBell class
            // Since it conforms to ITrackable -- done after creating the TacoBell class.

            return tacoBell;
        }
    }
}