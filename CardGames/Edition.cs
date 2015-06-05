using System;
using CardGames.CardLists;

namespace CardGames
{
    [Serializable]
    public class Edition
    {
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        private int? _yearOfRelease; // atr. opcjonalny

        public string YearOfRelease
        {
            get { return _yearOfRelease == null ? "<none>" : _yearOfRelease.ToString(); }
        }

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
            _yearOfRelease = yearOfRelease;
        }

        public void SetCardList(EditionCardList cardList)
        {
            if (cardList != CardList)
            {
                if (CardList != null)
                {
                    CardList.ResetEdition();
                }
                CardList = cardList;
                CardList.SetEdition(this);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}\nRelease year: {1}", Name, YearOfRelease);
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
