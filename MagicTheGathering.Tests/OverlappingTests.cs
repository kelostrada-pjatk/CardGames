using System;
using System.Collections.Generic;
using CardGames.Exceptions;
using MagicTheGathering.Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MagicTheGathering.Tests
{
    [TestClass]
    public class OverlappingTests
    {
        [TestMethod]
        public void OverlappingName()
        {
            var card = new MagicCard("Spined Thopter", "Flying", new HashSet<CardType>
            {
                new Artifact(),
                new Creature(2, 1)
            }, null);

            Assert.AreEqual("Artifact Creature", card.Type);
        }

        [TestMethod]
        public void CreaturePowerAndShield()
        {
            var card = new MagicCard("Scoria Elemental", "", 6, 1, null);
            Assert.AreEqual(6, card.Power);
            Assert.AreEqual(1, card.Shield);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongCardTypeException))]
        public void NonCreaturePowerShouldThrow()
        {
            var card = new MagicCard("Island", "", 'U', null);
            var power = card.Power;
        }
    }
}
