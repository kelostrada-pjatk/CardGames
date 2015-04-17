using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Social
{
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
