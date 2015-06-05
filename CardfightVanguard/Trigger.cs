using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfightVanguard
{
    public enum TriggerType
    {
        Critical,
        Heal,
        Stand,
        Draw
    }

    public class Trigger : CardfightCard
    {
        public Trigger(string name, string description, int power, TriggerType type) 
            : base(name, description, power)
        {
            TriggerType = type;
        }

        public TriggerType TriggerType { get; private set; }
    }
}
