using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    [Serializable]
    public abstract class CardList : ClassExtension
    {
        [Serializable]
        public class CardWithQuantity
        {
            public Card Card { get; set; }
            public int Quantity { get; set; }

            public CardWithQuantity(Card card, int quantity)
            {
                Card = card;
                Quantity = quantity;
            }
        }

        public bool Public { get; set; }
        public string Name { get; set; }

        public abstract string Link { get; }

        protected Dictionary<int, CardWithQuantity> CardsList = new Dictionary<int, CardWithQuantity>();

        protected CardList(bool isPublic, string name)
        {
            Public = isPublic;
            Name = name;
        }

        protected CardWithQuantity GetCard(Card card)
        {
            return CardsList.Values.FirstOrDefault(c => c.Card == card);
        }

        public void AddCard(Card card)
        {
            var cardWithQuantity = GetCard(card);
            int index;
            if (cardWithQuantity == null)
            {
                index = CardsList.Keys.Count == 0 ? 1 : CardsList.Keys.Max() + 1;
            }
            else
            {
                index = CardsList.First(p => p.Value.Card == card).Key;
            }
            AddCard(index, card);
        }

        public void AddCards(IEnumerable<Card> cards)
        {
            foreach (var c in cards)
            {
                AddCard(c);
            }
        }

        public void AddCard(int index, Card card)
        {
            AddCard(index, card, 1);
        }

        public virtual void AddCard(int index, Card card, int quantity)
        {
            if (CardsList.ContainsKey(index) && card == CardsList[index].Card)
            {
                CardsList[index].Quantity += quantity;
            }
            else if (CardsList.Any(c => c.Value.Card == card))
            {
                throw new Exception("The indexes of given card don't match");
            }
            else
            {
                CardsList.Add(index, new CardWithQuantity(card, quantity));
            }
        }

        public void RemoveCard(Card card)
        {
            if (CardsList.All(c => c.Value.Card != card))
            {
                throw new Exception("Card list does not contain selected card.");
            }
            RemoveCard(CardsList.First(c => c.Value.Card == card).Key);
        }

        public void RemoveCard(int index)
        {
            RemoveCard(index, 1);
        }

        public virtual void RemoveCard(int index, int quantity)
        {
            if (!CardsList.ContainsKey(index))
            {
                throw new Exception("Card list does not contain selected card.");
            }
            var card = CardsList[index];
            if (card.Quantity > quantity)
            {
                card.Quantity -= quantity;
            }
            else
            {
                CardsList.Remove(index);
            }
        }
    }
}
