using System;

namespace CardGames.CardLists
{
    [Serializable]
    public class Collection : CardList
    {
        public override string Link
        {
            get { throw new NotImplementedException(); }
        }

        public Collection(bool isPublic, string name) : base(isPublic, name)
        {
        }
    }
}
