
using System;

namespace CardGames.Social
{
    [Serializable]
    public class Message : BaseMessage
    {
        public User Recipient { get; private set; }

        public string Title { get; private set; }

        public Message(string description, string title, User author, User recipient)
            : base(description, author)
        {
            Recipient = recipient;
            Title = title;
        }

        public override string HtmlContent
        {
            get { return String.Format("Title: {0}<br>Description: {1}", Title, Description); }
        }
    }
}
