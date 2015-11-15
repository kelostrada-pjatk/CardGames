using System;
using System.Collections.Generic;
using System.Linq;
using CardGames.CardLists;

namespace CardGames
{
    [Serializable]
    public class Card : ClassExtension
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsPublished { get; private set; }

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
            IsPublished = null;
            Lists = new List<CardInList>();
        }

        public void Publish()
        {
            IsPublished = true;
        }

        public void Hide()
        {
            IsPublished = false;
        }

        public override string ToString()
        {
            return String.Format("{0}\nDescription:\n{1}\nPublish State: {2}", Name, Description, IsPublished ?? (object) "not set");
        }

        protected List<CardInList> Lists { get; set; } // Asocjacja z atrybutem

        public void AddList(CardInList cardInList)
        {
            if (!Lists.Contains(cardInList))
            {
                Lists.Add(cardInList);
            }
        }

        #region old
        public void AddToList(CardInList cardInList)
        {
            if (Lists.Any(l => l.Card == cardInList.Card)) return;

            Lists.Add(cardInList);
            cardInList.CardList.AddCard(this);
        }
        #endregion

    }
}
