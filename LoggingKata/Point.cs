namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point (double latitude, double longitude) //This is created after defining the TacoParser method's parms; make sure this is in the correct order.
        {
            Longitude = longitude;
            Latitude = latitude;   
        }

        //No default constructor is created - not needed?
    }
}