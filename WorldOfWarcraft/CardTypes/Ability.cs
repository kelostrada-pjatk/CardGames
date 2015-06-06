using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft.CardTypes
{
    public class Ability : CardType
    {
        public string Description { get; protected set; }

        public Ability(string description)
        {
            Description = description;
        }

        public override CardType Copy()
        {
            return new Ability(Description);
        }
    }
}
