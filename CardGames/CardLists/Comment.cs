using System;
using CardGames.Social;

namespace CardGames.CardLists
{
    public partial class Deck
    {
        [Serializable]
        public class Comment : BaseMessage
        {
            public Comment(string description, User author)
                : base(description, author)
            {
            }

            public override string HtmlContent
            {
                get { return String.Format("<p>{0}</p>", Description); }
            }
        }
    }
}
