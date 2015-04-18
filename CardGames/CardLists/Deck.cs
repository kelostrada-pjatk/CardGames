using System;
using System.Collections.Generic;
using CardGames.Social;

namespace CardGames.CardLists
{
    [Serializable]
    public class Deck : CardList
    {
        public User Owner { get; private set; }
        private readonly HashSet<Comment> _comments = new HashSet<Comment>(); // atr. powt.

        public override string Link
        {
            get { throw new NotImplementedException(); }
        }

        public Deck(bool isPublic, string name, User owner) 
            : base(isPublic, name)
        {
            Owner = owner;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public Deck Clone(User newOwner)
        {
            throw new NotImplementedException("TODO - later");
        }
    }
}
