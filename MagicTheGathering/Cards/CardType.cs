using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards
{
    public abstract class CardType : ICloneable
    {
        /// <summary>
        /// Implemented like this, so HashSet won't be able to hold more than
        /// one instance of each class this way
        /// </summary>
        public override bool Equals(object obj)
        {
            return GetType() == obj.GetType();
        }

        public abstract CardType Copy();

        public object Clone()
        {
            return Copy();
        }
    }
}
