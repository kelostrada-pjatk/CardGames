using System;
using System.Collections.Generic;
using System.Linq;
using CardGames.CardLists;

namespace CardGames
{
    [Serializable]
    public abstract class CardList : ClassExtension
    {

        public bool Public { get; set; }
        public string Name { get; set; }

        public int Quantity
        {
            get
            {
                return Cards.Sum(c => c.Quantity);
            }
        }

        public abstract string Link { get; }

        protected List<CardInList> Cards { get; set; }
        
        protected CardList(bool isPublic, string name)
        {
            Public = isPublic;
            Name = name;
            Cards = new List<CardInList>();
        }

        protected CardInList GetCard(Card card)
        {
            return Cards.FirstOrDefault(c => c.Card == card);
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (var c in cards)
            {
                AddCard(c);
            }
        }

        public void AddCard(Card card)
        {
            var cardInList = GetCard(card);
            int index;
            if (cardInList == null)
            {
                index = Cards.Count == 0 ? 1 : Cards.Max(c => c.Index) + 1;
            }
            else
            {
                index = Cards.First(p => p.Card == card).Index;
            }
            AddCard(index, card);
        }

        public void AddCard(int index, Card card)
        {
            AddCard(index, card, 1);
        }

        public virtual void AddCard(int index, Card card, int quantity)
        {
            var cardInList = Cards.FirstOrDefault(c => c.Index == index);
            if (cardInList != null && cardInList.Card == card)
            {
                cardInList.Quantity += quantity;
            }
            else if (Cards.Any(c => c.Card == card))
            {
                throw new Exception("The indexes of given card don't match");
            }
            else
            {
                cardInList = new CardInList(card, this, index, quantity);
                Cards.Add(cardInList);
                card.AddToList(cardInList);
            }
        }

        public void RemoveCard(Card card)
        {
            if (Cards.All(c => c.Card != card))
            {
                throw new Exception("Card list does not contain selected card.");
            }
            RemoveCard(Cards.First(c => c.Card == card).Index);
        }

        public void RemoveCard(int index)
        {
            RemoveCard(index, 1);
        }

        public virtual void RemoveCard(int index, int quantity)
        {
            if (Cards.All(c => c.Index != index))
            {
                throw new Exception("Card list does not contain selected card.");
            }
            var cardInList = Cards.First(c => c.Index == index);
            if (cardInList.Quantity > quantity)
            {
                cardInList.Quantity -= quantity;
            }
            else
            {
                Cards.Remove(cardInList);
            }
        }
    }
}
