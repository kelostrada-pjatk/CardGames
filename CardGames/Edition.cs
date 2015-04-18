using System;
using CardGames.CardLists;

namespace CardGames
{
    [Serializable]
    public class Edition
    {
        public string Name { get; private set; }
        private int? _yearOfRelease; // atr. opcjonalny

        public string YearOfRelease
        {
            get { return _yearOfRelease == null ? "<none>" : _yearOfRelease.ToString(); }
        }

        public Game Game { get; private set; } // atr. złożony
        public EditionCardList CardList { get; private set; }

        public Edition(Game game, string name)
        {
            Game = game;
            Game.AddEdition(this);
            Name = name;
            CardList = new EditionCardList(this);
        }

        public Edition(Game game, string name, int yearOfRelease)
            : this(game, name)
        {
            _yearOfRelease = yearOfRelease;
        }

        public override string ToString()
        {
            return String.Format("{0}\nRelease year: {1}", Name, YearOfRelease);
        }
    }
}
