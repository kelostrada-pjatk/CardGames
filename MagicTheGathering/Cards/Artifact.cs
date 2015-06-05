using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTheGathering.Cards
{
    public class Artifact : CardType
    {
        private static Artifact _instance;

        public static Artifact Instance
        {
            get { return _instance ?? (_instance = new Artifact()); }
        }

        public override CardType Copy()
        {
            return new Artifact();
        }
    }
}
