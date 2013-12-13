using NUnit.Framework;
using NeocronWorldMap.Web.Domain;

namespace Test.NeocronWorldMap.Web.Domain
{
    [TestFixture]
    public class TestFaction
    {
        [Test]
        public void Factions_with_same_names_are_equal()
        {
            var faction1 = new Faction("foo");
            var faction2 = new Faction("foo");

            Assert.That(faction1, Is.EqualTo(faction2), "factions not equal with same name");
        }
    }
}