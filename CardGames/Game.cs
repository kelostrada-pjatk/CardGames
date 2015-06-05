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
        protected Dictionary<String, Edition> Editions { get; private set; } // Asocjacja kwalifikowana

        public Game(string name, int yearOfRelease)
        {
            Name = name;
            _yearOfRelease = yearOfRelease;
            Editions = new Dictionary<string, Edition>();
        }

        public void AddEdition(Edition edition)
        {
            if (edition.Game != this)
            {
                edition.Game.RemoveEdition(edition);
            }
            if (!Editions.ContainsKey(edition.Symbol))
            {
                Editions.Add(edition.Symbol, edition);
                edition.SetGame(this);
            }
        }

        public void AddEdition(string symbol, string name, int yearOfRelease)
        {
            var edition = new Edition(this, symbol, name, yearOfRelease);
            AddEdition(edition);
        }

        public Edition GetEdition(string symbol)
        {
            return Editions.ContainsKey(symbol) ? Editions[symbol] : null;
        }

        public override string ToString()
        {
            var editionsString = Editions.Aggregate("", (current, e) => current + e.ToString());
            return String.Format("{0}.\nRelease year: {1}\nEditions: \n{2}", Name, YearOfRelease, editionsString);
        }

        public void RemoveEdition(Edition edition)
        {
            if (Editions.ContainsKey(edition.Symbol))
            {
                Editions.Remove(edition.Symbol);
            }
        }
    }
}
