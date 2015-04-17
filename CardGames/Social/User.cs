using System;
using System.Collections.Generic;
using CardGames.CardLists;

namespace CardGames.Social
{
    [Serializable]
    public class User : ClassExtension
    {
        public string Login { get; private set; }
        private int Password { get; set; }
        public string Email { get; private set; }
        private readonly HashSet<Deck> _decks = new HashSet<Deck>(); 

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password.GetHashCode();
            Email = email;
        }

        public bool CheckLogin(string password)
        {
            return password.GetHashCode() == Password;
        }

        public void Comment(Deck deck, string commentDescription)
        {
            var comment = new Comment(commentDescription, this);
            deck.AddComment(comment);
        }

        public Deck CreateDeck(string name)
        {
            var deck = new Deck(false, name, this);
            _decks.Add(deck);
            return deck;
        }

        public Deck CopyDeck(Deck deck)
        {
            deck = deck.Clone(this);
            _decks.Add(deck);
            return deck;
        }
    }
}
