using System;
using System.Text;
using System.Collections.Generic;
using MagicTheGathering.Cards;
using MagicTheGathering.Cards.SubTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTheGathering.Tests
{
    /// <summary>
    /// Summary description for SubTypeTests
    /// </summary>
    [TestClass]
    public class SubTypeTests
    {
        [TestMethod]
        public void DragonFamilyName()
        {
            var card = new MagicCard("Dromoka, the Eternal", "", new HashSet<CardType>
            {
                new Creature(5, 5)
            }, new Dragon("Dromoka"));
            Assert.AreEqual("Dromoka", card.FamilyName);
        }
    }
}
