using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft
{
    public class MageCard : WarcraftCard
    {
        public bool DrawsCard { get; protected set; }
        public MageCard(string name, string description, CardType cardType) : base(name, description, cardType)
        {
        }
    }
}
