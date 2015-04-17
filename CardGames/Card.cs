using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public class Card : ClassExtension
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
