using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfightVanguard
{
    public class Shield : CardfightCard, IShield
    {
        public Shield(string name, string description, int power, int shield)
            : base(name, description, power)
        {
            ShieldValue = shield;
        }

        public int ShieldValue { get; private set; }
    }
}
