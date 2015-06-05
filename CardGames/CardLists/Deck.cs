using System;
using System.Collections.Generic;
using System.Linq;
using CardGames.Social;

namespace CardGames.CardLists
{
    [Serializable]
    public partial class Deck : CardList
    {
        public User Owner { get; private set; }
        private readonly Dictionary<int, Comment> _comments = new Dictionary<int, Comment>(); // kompozycja

        public List<Comment> Comments
        {
            get { return _comments.Select(kvp => kvp.Value).ToList(); }
        } 

        private static int _autonumCommentId = 0;

        public override string Link
        {
            get { throw new NotImplementedException(); }
        }

        public Deck(bool isPublic, string name, User owner) 
            : base(isPublic, name)
        {
            Owner = owner;
        }

        public Comment GetComment(int commentId)
        {
            Comment comment;
            if (_comments.TryGetValue(commentId, out comment))
            {
                return comment;
            }
            return null;
        }

        public string GetCommentDescription(int commentId)
        {
            var comment = GetComment(commentId);
            if (comment != null)
            {
                return comment.Description;
            }
            return null;
        }

        public User GetAuthor(int commentId)
        {
            var comment = GetComment(commentId);
            if (comment != null)
            {
                return comment.Author;
            }
            return null;
        }

        public int AddComment(string message, User author)
        {
            var comment = new Comment(message, author);
            var commentId = ++_autonumCommentId;
            _comments.Add(commentId, comment);
            return commentId;
        }

        public void RemoveComment(int commentId)
        {
            if (_comments.ContainsKey(commentId))
            {
                var comment = _comments[commentId];
                _comments.Remove(commentId);
                comment.RemoveFromExtensions();
            }
        }

        public Deck Clone(User newOwner)
        {
            throw new NotImplementedException("TODO - later");
        }

        
    }
}
