using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards
{
    public class Land : CardType
    {
        public char Mana { get; private set; }

        public Land(char mana)
        {
            Mana = mana;
        }

        private static Land _instance;

        public static Land Instance
        {
            get { return _instance ?? (_instance = new Land('-')); }
        }

        public override CardType Copy()
        {
            return new Land(Mana);
        }
    }
}
