using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void NotNullParse()
        {
            // TODO: Complete Something, if anything
            

            //Arrange
            var tacoParser = new TacoParser();

            //Act - The parsed method is being assigned to var actual as a confirmation value for comparasion 
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert - Checks if it's able to parse using the params.
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange --Write code that is needed to call the tested method.

            var tacoParser = new TacoParser();

            //Act

            var actual = tacoParser.Parse(line).Location.Longitude;

            Assert.Equal(expected, actual);
        }


        //TODO: Create a test ShouldParseLatitude

        [Theory]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", 32.571331)]
       public void ShouldParseLatitude(string line, double expected)
        {

            //Arrange --Write code that is needed to call the tested method.

            var tacoParser = new TacoParser();

            //Act

            var actual = tacoParser.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }
    }
}
