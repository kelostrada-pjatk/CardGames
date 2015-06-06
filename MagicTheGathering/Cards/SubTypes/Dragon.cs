using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards.SubTypes
{
    public class Dragon : SubType
    {
        public string FamilyName { get; private set; }

        public Dragon(string familyName)
        {
            FamilyName = familyName;
        }

        public override SubType Copy()
        {
            return new Dragon(FamilyName);
        }
    }
}
