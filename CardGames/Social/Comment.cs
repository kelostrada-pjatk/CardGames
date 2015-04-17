using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Social
{
    [Serializable]
    public class Comment : BaseMessage
    {
        public Comment(string description, User author) 
            : base(description, author)
        {
        }

    }
}
