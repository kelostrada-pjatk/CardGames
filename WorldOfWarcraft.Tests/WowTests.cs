using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldOfWarcraft.CardTypes;

namespace WorldOfWarcraft.Tests
{
    [TestClass]
    public class WowTests
    {
        [TestMethod]
        public void WowTest()
        {
            var card = new WarriorCard("Recklessness", "", new Ability("Ongoing"));
            card.GainArmor(1);
            Assert.AreEqual("Ongoing", card.AbilityDescription);
            Assert.AreEqual(1, card.Armor);
        }
    }
}
