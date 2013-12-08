using NUnit.Framework;
using NeocronWorldMap.Web.Domain;

namespace Test.NeocronWorldMap.Web.Domain
{
    [TestFixture]
    public class TestCoordinates
    {
        [Test]
        public void Coordinates_with_same_properties_are_equal()
        {
            var coordinates1 = new Coordinates("99", 'x');
            var coordinates2 = new Coordinates("99", 'x');

            Assert.That(coordinates1, Is.EqualTo(coordinates2), "did not equal");
        }

        [Test]
        public void Coordinates_with_different_properties_are_unequal()
        {
            var coordinates1 = new Coordinates("99", 'x');
            var coordinates2 = new Coordinates("55", 'd');

            Assert.That(coordinates1, Is.Not.EqualTo(coordinates2), "different coordinates were equal");
        }
    }
}