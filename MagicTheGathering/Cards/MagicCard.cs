using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames;
using MagicTheGathering.Exceptions;

namespace MagicTheGathering.Cards
{
    public class MagicCard : Card
    {
        #region Constructors

        protected MagicCard(string name, string description) : base(name, description)
        {
            Types = new HashSet<CardType>();
        }

        /// <summary>
        /// Universal constructor
        /// </summary>
        public MagicCard(string name, string description, HashSet<CardType> types)
            : this(name, description)
        {
            foreach (var type in types)
            {
                Types.Add(type.Copy());
            }
        }

        /// <summary>
        /// Constructor for Land
        /// </summary>
        public MagicCard(string name, string description, char mana) : this(name, description)
        {
            Types.Add(new Land(mana));
        }

        /// <summary>
        /// Constructor for Creature
        /// </summary>
        public MagicCard(string name, string description, int power, int shield)
            : this(name, description)
        {
            Types.Add(new Creature(power, shield));
        }

        #endregion

        #region Overlapped types

        protected HashSet<CardType> Types { get; set; }

        protected Creature Creature
        {
            get
            {
                return (Creature)Types.FirstOrDefault(c => c.Equals(Creature.Instance));
            }
        }

        protected Land Land
        {
            get
            {
                return (Land)Types.FirstOrDefault(c => c.Equals(Land.Instance));
            }
        }

        protected Artifact Artifact
        {
            get
            {
                return (Artifact)Types.FirstOrDefault(c => c.Equals(Artifact.Instance));
            }
        }

        #endregion

        public String Type
        {
            get { return Types.Aggregate("", (current, t) => current + (t.GetType().Name + " ")).Trim(); }
        }

        public int Power
        {
            get
            {
                if (Creature == null)
                {
                    throw new WrongCardTypeException();
                }
                return Creature.Power;
            }
        }

        public int Shield
        {
            get
            {
                if (Creature == null)
                {
                    throw new WrongCardTypeException();
                }
                return Creature.Shield;
            }
        }

    }
}
