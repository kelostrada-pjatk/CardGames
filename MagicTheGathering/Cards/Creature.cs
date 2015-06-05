using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards
{
    public class Creature : CardType
    {
        public int Power { get; private set; }

        public int Shield { get; private set; }
        
        public Creature(int power, int shield)
        {
            Power = power;
            Shield = shield;
        }

        private static Creature _instance;

        public static Creature Instance
        {
            get { return _instance ?? (_instance = new Creature(0, 0)); }
        }

        public override CardType Copy()
        {
            return new Creature(Power, Shield);
        }
    }
}
