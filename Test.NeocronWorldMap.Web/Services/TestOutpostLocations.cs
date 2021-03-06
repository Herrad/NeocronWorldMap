using NUnit.Framework;
using NeocronWorldMap.Web.Domain;
using NeocronWorldMap.Web.Services;

namespace Test.NeocronWorldMap.Web.Services
{
    [TestFixture]
    public class TestOutpostLocations
    {
        [TestCase("04", 'k', "Rockshore Factory")]
        [TestCase("05", 'k', "Drakhan Fortress")]
        [TestCase("07", 'k', "Northstar Uplink")]
        [TestCase("12", 'k', "Tescom Uplink")]
        [TestCase("09", 'j', "Yutano Mine")]
        [TestCase("14", 'j', "Syncon Lab")]
        [TestCase("04", 'i', "Sieger Uplink")]
        [TestCase("05", 'i', "Chester Lab")]
        [TestCase("07", 'i', "Emmerson Factory")]
        [TestCase("08", 'i', "Avenger Mine")]
        [TestCase("11", 'i', "Tristar Uplink")]
        [TestCase("15", 'i', "Cajun Uplink")]
        [TestCase("03", 'h', "Jankins Lab")]
        [TestCase("07", 'h', "Hawkins Uplink")]
        [TestCase("09", 'h', "Malstrond Factory")]
        [TestCase("11", 'h', "Blackhill Fortress")]
        [TestCase("13", 'h', "Nemesis Lab")]
        [TestCase("15", 'h', "Soliko Lab")]
        [TestCase("16", 'h', "Eastgate Factory")]
        [TestCase("08", 'g', "Gabanium Mine")]
        [TestCase("12", 'g', "Tezla Factory")]
        [TestCase("05", 'f', "Regant Fortress")]
        [TestCase("11", 'f', "Devereaux Fortress")]
        [TestCase("12", 'f', "Cycrow Lab")]
        [TestCase("10", 'e', "Shirkan Fortress")]
        [TestCase("06", 'd', "Gravis Uplink")]
        [TestCase("07", 'd', "Redrock Mine")]
        [TestCase("09", 'd', "Crest Uplink")]
        [TestCase("11", 'd', "Foster Uplink")]
        [TestCase("13", 'd', "Grant Mine")]
        [TestCase("07", 'c', "Tyron Factory")]
        [TestCase("09", 'c', "Krupp Factory")]
        [TestCase("12", 'c', "Ceres Mine")]
        [TestCase("08", 'b', "Jeriko Fortress")]
        [TestCase("11", 'b', "McPherson Factory")]
        [TestCase("06", 'a', "Simmons Factory")]
        public void Returns_an_outpost_when_an_outpost_exists_in_that_zone(string xCoordinate, char yCoordinate, string expectedOutpostName)
        {
            var outpostLocations = new OutpostLocations();

            var coordinates = new Coordinates(xCoordinate, yCoordinate);

            var outpostName = outpostLocations.GetOutpostNameAt(coordinates);

            Assert.That(outpostName, Is.EqualTo(expectedOutpostName));
        }

        [Test]
        public void Returns_no_outpost_when_zone_has_no_outpost()
        {
            var outpostLocations = new OutpostLocations();

            var outpostName = outpostLocations.GetOutpostNameAt(new Coordinates("99", 'x'));

            Assert.That(outpostName, Is.EqualTo("No outpost found"));
        }
    }
}