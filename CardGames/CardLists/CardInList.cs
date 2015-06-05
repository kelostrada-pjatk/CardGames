using System;

namespace CardGames.CardLists
{
    [Serializable]
    public class CardInList : ClassExtension
    {
        public CardInList(Card card, CardList cardList, int index)
        {
            Card = card;
            
            CardList = cardList;
            Index = index;
            Quantity = 1;
            Card.AddList(this);
            CardList.AddCard(this);
        }

        public CardInList(Card card, CardList cardList, int index, int quantity)
            : this(card, cardList, index)
        {
            Quantity = quantity;
        }

        public int Index { get; set; }
        public int Quantity { get; set; }
        public Card Card { get; set; }
        public CardList CardList { get; set; }

    }
}
