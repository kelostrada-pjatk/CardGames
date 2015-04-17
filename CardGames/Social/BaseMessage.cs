using System;

namespace CardGames.Social
{
    [Serializable]
    public abstract class BaseMessage : ClassExtension
    {
        public string Description { get; protected set; }
        public User Author { get; protected set; }
        public DateTime SendDate { get; protected set; }

        protected BaseMessage(string description, User author)
        {
            Description = description;
            Author = author;
            SendDate = DateTime.Now;
        }

    }
}
