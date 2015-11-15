using System;

namespace CardGames.Social
{
    [Serializable]
    public abstract class BaseMessage : ClassExtension
    {
        public string Description { get; protected set; }
        private User _author;

        public User Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (_author != value)
                {
                    if (_author != null)
                    {
                        _author.RemoveMessage(this);
                    }
                    _author = value;
                    _author.AddMessage(this);
                }
            }
        }

        public DateTime SendDate { get; protected set; }

        protected BaseMessage(string description, User author)
        {
            Description = description;
            Author = author;
            SendDate = DateTime.Now;
        }

        // polimorfizm
        public abstract string HtmlContent { get; }

    }
}
