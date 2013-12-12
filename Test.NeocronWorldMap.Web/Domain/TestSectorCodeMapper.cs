using NUnit.Framework;
using NeocronWorldMap.Web.Domain;

namespace Test.NeocronWorldMap.Web.Domain
{
    [TestFixture]
    public class TestSectorCodeMapper
    {
        [TestCase('a', "06", 2006)]
        [TestCase('b', "10", 2030)]
        [TestCase('i', "11", 2171)]
        public void Converts_coordinates_to_sector_code(char yCoordinate, string xCoordinate, int expectedCode)
        {
            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var sectorCodeMapper = new SectorCodeMapper();

            var sectorCode = sectorCodeMapper.Map(coordinates);
        
            Assert.That(sectorCode, Is.EqualTo(expectedCode));
        }
    }
}