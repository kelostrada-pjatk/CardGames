using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    [Serializable]
    public abstract class CardList
    {
        public bool Public { get; set; }
        public bool Name { get; set; }

        public abstract string Link { get; }

        protected Dictionary<int, Card> List = new Dictionary<int, Card>();

        public void AddCard(Card card)
        {
            
        }
    }
}
