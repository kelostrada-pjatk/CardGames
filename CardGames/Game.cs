using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public class Game
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

    }
}
