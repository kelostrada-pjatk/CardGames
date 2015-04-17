using System;
using System.Collections.Generic;

namespace CardGames
{
    [Serializable]
    public class Game : ClassExtension
    {
        public string Name { get; private set; }
        public int YearOfRelease { get; private set; }

        private readonly HashSet<Edition> _editions = new HashSet<Edition>(); 

        public Game(string name, int yearOfRelease)
        {
            Name = name;
            YearOfRelease = yearOfRelease;
        }

        public void AddEdition(Edition edition)
        {
            if (edition.Game != this)
            {
                throw new Exception("Cannon add edition to multiple games");
            }
            _editions.Add(edition);
        }

        public void AddEdition(string name, int yearOfRelease)
        {
            var edition = new Edition(this, name, yearOfRelease);
            AddEdition(edition);
        }
    }
}
