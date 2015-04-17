using System;

namespace CardGames
{
    [Serializable]
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
