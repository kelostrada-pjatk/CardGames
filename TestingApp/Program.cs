using System;
using CardGames;

namespace TestingApp
{
    class Program
    {
        static void PrintAll<T>() where T : ClassExtension
        {
            foreach (var elem in ClassExtension.GetAll<T>())
            {
                Console.WriteLine(elem);
            }
        }

        static void Main(string[] args)
        {
            ClassExtension.LoadData();

            PrintAll<Game>();
            PrintAll<Card>();

            /*
            var magic = new Game("Magic the gathering", 1995);
            var edition = new Edition(magic, "Khanks of Tarkir", 2014);
            edition.CardList.AddCard(new Card("Abomination of Gudul", "Whenever Abomination of Gudul deals combat damage to a player, you may draw a card. If you do, discard a card."));
            magic.AddEdition(edition);
            */
            ClassExtension.SaveData();


        }
    }
}
