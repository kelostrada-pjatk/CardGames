using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfightVanguard
{
    public class ShieldWithTrigger : Trigger, IShield
    {
        protected Shield Shield { get; set; }

        public ShieldWithTrigger(string name, string description, int power, TriggerType type, int shield)
            : base(name, description, power, type)
        {
            Shield = new Shield(name, description, power, shield);
        }

        public int ShieldValue
        {
            get { return Shield.ShieldValue; }
        }
    }
}
