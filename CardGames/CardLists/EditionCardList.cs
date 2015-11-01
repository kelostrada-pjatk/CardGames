using System;
using System.Linq;

namespace CardGames.CardLists
{
    [Serializable]
    public class EditionCardList : CardList
    {
        public Edition Edition { get; private set; } // Asocjacja Binarna

        public override string Link
        {
            get { throw new NotImplementedException(); }
        }

        public EditionCardList(Edition edition) : 
            base(true, edition.Name)
        {
            SetEdition(edition);
        }

        public void SetEdition(Edition edition)
        {
            if (Edition != edition)
            {
                if (Edition != null)
                {
                    Edition.ResetCardList();
                }
                Edition = edition;
                Edition.SetCardList(this);
            }
        }

        /// <summary>
        /// przesłonięcie metod
        /// </summary>
        public override void AddCard(int index, Card card, int quantity)
        {
            if (Cards.Count > 0 && Cards.Any(c => c.Index == index))
            {
                return;
            }
            if (Cards.Any(c => c.Card == card))
            {
                throw new Exception("Cannot add the same card twice");
            }
            if (quantity != 1)
            {
                throw new Exception("Edition cannot have more than one card of a type");
            }
            base.AddCard(index, card, 1);
        }

        public void ResetEdition()
        {
            if (Edition != null)
            {
                var edition = Edition;
                Edition = null;
                edition.ResetCardList();
            }
        }
    }
}
