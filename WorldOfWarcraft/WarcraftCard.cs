using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames;
using CardGames.Exceptions;
using WorldOfWarcraft.CardTypes;

namespace WorldOfWarcraft
{
    public abstract class WarcraftCard : Card
    {
        public CardType Type { get; protected set; }

        protected WarcraftCard(string name, string description, CardType cardType) : base(name, description)
        {
            if (cardType != null)
            {
                Type = cardType.Copy();
            }

        }

        public int Power
        {
            get
            {
                var type = (Ally) Type;
                if (type == null)
                {
                    throw new WrongCardTypeException();
                }
                return type.Power;
            }
        }

        public int Shield
        {
            get
            {
                var type = (Ally)Type;
                if (type == null)
                {
                    throw new WrongCardTypeException();
                }
                return type.Shield;
            }
        }

        public int WeaponAttack
        {
            get
            {
                var type = (Weapon)Type;
                if (type == null)
                {
                    throw new WrongCardTypeException();
                }
                return type.Attack;
            }
        }

        public string AbilityDescription
        {
            get
            {
                var type = (Ability)Type;
                if (type == null)
                {
                    throw new WrongCardTypeException();
                }
                return type.Description;
            }
        }

    }
}
