using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards
{
    public abstract class SubType : ICloneable
    {
        public abstract SubType Copy();

        public object Clone()
        {
            return Copy();
        }
    }
}
