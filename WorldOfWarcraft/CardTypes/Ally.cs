using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft.CardTypes
{
    public class Ally : CardType
    {
        public int Power { get; protected set; }
        public int Shield { get; private set; }

        public Ally(int power, int shield)
        {
            Power = power;
            Shield = shield;
        }

        public override CardType Copy()
        {
            throw new NotImplementedException();
        }
    }
}
