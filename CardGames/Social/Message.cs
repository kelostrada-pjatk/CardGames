
using System;

namespace CardGames.Social
{
    [Serializable]
    public class Message : BaseMessage
    {
        public User Recipient { get; private set; }

        public Message(string description, User author, User recipient) 
            : base(description, author)
        {
            Recipient = recipient;
        }
    }
}
