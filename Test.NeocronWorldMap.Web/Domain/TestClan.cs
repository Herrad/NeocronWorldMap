using System;
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

            Assert.That(clan.Faction, Is.Not.Null);
            Assert.That(clan.Faction.Name, Is.EqualTo("Not applicable"));

            Assert.That(clan.TimeOwnedFor , Is.EqualTo(new TimeSpan()));
        }

        [Test]
        public void Clans_with_different_names_are_not_equal()
        {
            var clan1 = new Clan("clan1", null, new TimeSpan(), 0);
            var clan2 = new Clan("clan2", null, new TimeSpan(), 0);

            Assert.That(clan1, Is.Not.EqualTo(clan2));
        }

        [Test]
        public void Clans_with_same_name_are_equal()
        {
            var clan1 = new Clan("clan1", null, new TimeSpan(), 0);
            var clan2 = new Clan("clan1", null, new TimeSpan(), 0);

            Assert.That(clan1, Is.EqualTo(clan2), "clans weren't equal");
        }

        [TestCase(0, "AN/GRA")]
        [TestCase(5, "AE/GRFR")]
        [TestCase(10, "AFA/GRFA")]
        [TestCase(15, "AE/GRC")]
        public void Converts_SecutrityCode_into_status(int code, string expectedStatus)
        {
            var clan = new Clan("clan", new Faction("foo"), new TimeSpan(), code);

            var securityStatus = clan.GetSecurityStatus();

            Assert.That(securityStatus, Is.EqualTo(expectedStatus));
        }
    }
}