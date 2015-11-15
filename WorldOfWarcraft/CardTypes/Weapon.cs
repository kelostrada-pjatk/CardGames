using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft.CardTypes
{
    public class Weapon : CardType
    {
        public int Attack { get; protected set; }

        public Weapon(int attack)
        {
            Attack = attack;
        }

        public override CardType Copy()
        {
            throw new NotImplementedException();
        }
    }
}
