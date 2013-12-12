using NUnit.Framework;
using NeocronWorldMap.Web.Domain;

namespace Test.NeocronWorldMap.Web.Domain
{
    [TestFixture]
    public class TestClan
    {
        [Test]
        public void NotApplicable_returns_Empty_clan()
        {
            var clan = Clan.NotApplicable();

            Assert.That(clan, Is.Not.Null);
            Assert.That(clan.Name, Is.EqualTo("Not applicable"));
        }

        [Test]
        public void Clans_with_different_names_are_not_equal()
        {
            var clan1 = new Clan("clan1");
            var clan2 = new Clan("clan2");

            Assert.That(clan1, Is.Not.EqualTo(clan2));
        }

        [Test]
        public void Clans_with_same_name_are_equal()
        {
            var clan1 = new Clan("clan1");
            var clan2 = new Clan("clan1");

            Assert.That(clan1, Is.EqualTo(clan2), "clans weren't equal");
        }
    }
}