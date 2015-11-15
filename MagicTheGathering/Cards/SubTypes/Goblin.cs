using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards.SubTypes
{
    public class Goblin : SubType
    {
        public override SubType Copy()
        {
            return new Goblin();
        }
    }
}
