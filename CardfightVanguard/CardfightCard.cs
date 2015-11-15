using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames;

namespace CardfightVanguard
{
    public class CardfightCard : Card
    {
        public int Power { get; private set; }
        public CardfightCard(string name, string description, int power) : base(name, description)
        {
            Power = power;
        }
    }
}
