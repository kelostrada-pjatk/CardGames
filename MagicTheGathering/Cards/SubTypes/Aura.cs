using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards.SubTypes
{
    public enum AuraTarget { Player, Enchantment, Artifact, Creature }
    public class Aura : SubType
    {
        public AuraTarget AuraTarget { get; private set; }
        public Aura(AuraTarget auraTarget)
        {
            AuraTarget = auraTarget;
        }

        public override SubType Copy()
        {
            return new Aura(AuraTarget);
        }
    }
}
