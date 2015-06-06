using System;
using System.Collections.Generic;
using System.Linq;
using CardGames;
using CardGames.Exceptions;
using MagicTheGathering.Cards.SubTypes;

namespace MagicTheGathering.Cards
{
    public class MagicCard : Card
    {
        #region Constructors

        protected MagicCard(string name, string description, SubType subType) : base(name, description)
        {
            Types = new HashSet<CardType>();
            if (subType != null)
            {
                SubType = subType.Copy();
            }
        }

        /// <summary>
        /// Universal constructor
        /// </summary>
        public MagicCard(string name, string description, HashSet<CardType> types, SubType subType)
            : this(name, description, subType)
        {
            foreach (var type in types)
            {
                Types.Add(type.Copy());
            }
        }

        /// <summary>
        /// Constructor for Land
        /// </summary>
        public MagicCard(string name, string description, char mana, SubType subType)
            : this(name, description, subType)
        {
            Types.Add(new Land(mana));
        }

        /// <summary>
        /// Constructor for Creature
        /// </summary>
        public MagicCard(string name, string description, int power, int shield, SubType subType)
            : this(name, description, subType)
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

        #region second Aspect

        public SubType SubType { get; protected set; }

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

        public string FamilyName
        {
            get
            {
                var dragon = SubType as Dragon;
                if (dragon == null)
                {
                    throw new WrongCardTypeException(); 
                }
                return dragon.FamilyName;
            }
        }

        public AuraTarget AuraTarget
        {
            get
            {
                var aura = SubType as Aura;
                if (aura == null)
                {
                    throw new WrongCardTypeException();
                }
                return aura.AuraTarget;
            }
        }

    }
}
