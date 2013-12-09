using NUnit.Framework;
using NeocronWorldMap.Web.Domain;

namespace Test.NeocronWorldMap.Web.Domain
{
    [TestFixture]
    public class TestFactionFactory
    {
        [Test]
        public void BuildNext_returns_Next_faction()
        {
            var faction = FactionFactory.BuildNext();

            Assert.That(faction, Is.Not.Null);
            Assert.That(faction.Name, Is.EqualTo("NeXT"));
        } 
    }
}