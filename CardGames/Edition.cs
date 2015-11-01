using System;
using CardGames.CardLists;

namespace CardGames
{
    [Serializable]
    public class Edition
    {
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public int? YearOfRelease; // atr. opcjonalny
        
        public Game Game { get; private set; } // atr. złożony
        public EditionCardList CardList { get; private set; } // Asocjacja Binarna

        public Edition(Game game, string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
            Game = game;
            Game.AddEdition(this);
            SetCardList(new EditionCardList(this));
        }

        public Edition(Game game, string symbol, string name, int yearOfRelease)
            : this(game, symbol, name)
        {
           YearOfRelease = yearOfRelease;
        }

        public void SetCardList(EditionCardList cardList)
        {
            if (cardList == CardList) return;
            CardList?.ResetEdition();
            CardList = cardList;
            CardList.SetEdition(this);
        }

        public override string ToString()
        {
            return $"{Name}\nRelease year: {YearOfRelease?.ToString() ?? "<none>"}";
        }

        public void SetGame(Game game)
        {
            if (Game != game)
            {
                if (Game != null)
                {
                    Game.RemoveEdition(this);
                }
                Game = game;
                Game.AddEdition(this);
            }
        }

        public void ResetCardList()
        {
            if (CardList != null)
            {
                var cardList = CardList;
                CardList = null;
                cardList.ResetEdition();
            }
        }
    }
}
