using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    [Serializable]
    public class Game : ClassExtension
    {
        public string Name { get; private set; }

        private int? _yearOfRelease;

        public string YearOfRelease
        {
            get { return _yearOfRelease == null ? "<none>" : _yearOfRelease.ToString(); }
        }
        public HashSet<Edition> Editions { get; private set; }

        public Game(string name, int yearOfRelease)
        {
            Name = name;
            _yearOfRelease = yearOfRelease;
            Editions = new HashSet<Edition>(); 
        }

        public void AddEdition(Edition edition)
        {
            if (edition.Game != this)
            {
                throw new Exception("Cannon add edition to multiple games");
            }
            Editions.Add(edition);
        }

        public void AddEdition(string name, int yearOfRelease)
        {
            var edition = new Edition(this, name, yearOfRelease);
            AddEdition(edition);
        }

        public override string ToString()
        {
            var editionsString = Editions.Aggregate("", (current, e) => current + e.ToString());
            return String.Format("{0}.\nRelease year: {1}\nEditions: \n{2}", Name, YearOfRelease, editionsString);
        }
    }
}
