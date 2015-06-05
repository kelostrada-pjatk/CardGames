using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardfightVanguard.Tests
{
    [TestClass]
    public class MultipleInheritance
    {
        [TestMethod]
        public void TestMultipleInheritance()
        {
            var shieldWithTrigger = new ShieldWithTrigger("Demonic Dragon Mage, Rakshasa", "[AUTO](RC):During your main phase, when an opponent's rear-guard is put into the drop zone, this units gets [Power]+3000 until end of turn.", 3000, TriggerType.Critical, 10000);
            Assert.AreEqual(3000, shieldWithTrigger.Power);
            Assert.AreEqual(TriggerType.Critical, shieldWithTrigger.TriggerType);
            Assert.AreEqual(10000, shieldWithTrigger.ShieldValue);
            Assert.AreEqual("Demonic Dragon Mage, Rakshasa", shieldWithTrigger.Name);
        }
    }
}
