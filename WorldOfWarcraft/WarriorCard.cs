using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarcraft
{
    public class WarriorCard : WarcraftCard
    {
        public int Armor { get; protected set; }

        public WarriorCard(string name, string description, CardType cardType) : base(name, description, cardType)
        {
            Armor = 0;
        }

        public void GainArmor(int armor)
        {
            Armor += armor;
        }
    }
}
