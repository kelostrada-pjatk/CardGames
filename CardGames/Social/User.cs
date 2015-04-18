using System;
using System.Linq;
using System.Collections.Generic;
using CardGames.CardLists;

namespace CardGames.Social
{
    [Serializable]
    public class User : ClassExtension
    {
        public static int MinPasswordLength = 5;
        public string Login { get; private set; }
        private int Password { get; set; }
        public ContactData ContactData { get; private set; }

        private readonly HashSet<Deck> _decks = new HashSet<Deck>();
        
        public List<DateTime> LoginHistory { get; private set; }

        public DateTime LastLogin
        {
            get
            {
                return LoginHistory.Last();
            }
        }

        public User(string login, string password, string email, string phoneNumber)
        {
            if (password.Length < MinPasswordLength)
            {
                throw new Exception("Password too short");
            }
            Login = login;
            Password = password.GetHashCode();
            ContactData = new ContactData();
            ContactData.Email = email;
            ContactData.Phone = phoneNumber;
            LoginHistory = new List<DateTime>();
        }

        public bool CheckLogin(string password)
        {
            if (password.GetHashCode() == Password)
            {
                LoginHistory.Add(DateTime.Now);
                return true;
            }
            return false;
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

        public static User LoginUser(string login, string password) {
            var user = GetUserByLogin(login);
            if (user != null && user.CheckLogin(password))
            {
                return user;
            }
            return null;
        }

        public static List<User> GetAllUsers()
        {
            return GetAll<User>();
        }

        public static User GetUserByLogin(string login)
        {
            return GetAllUsers().FirstOrDefault(u => u.Login == login);
        }

    }
}
