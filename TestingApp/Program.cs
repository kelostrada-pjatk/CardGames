using System;
using System.Linq;
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
            
            /*
            
            var cardfight = new Game("Cardfight!! Vanguard", 2012);
            var edition = new Edition(cardfight, "Descent of the King of Knights");
            edition.CardList.AddCard(new Card("King of Knights, Alfred", "[CONT](VC):Your units cannot boost this unit."));
            edition.CardList.AddCard(new Card("Blaster Blade", "Blablabla"));
            cardfight.AddEdition(edition);
            
            var magic = new Game("Magic the gathering", 1995);
            edition = new Edition(magic, "Khanks of Tarkir", 2014);
            edition.CardList.AddCard(new Card("Abomination of Gudul", "Whenever Abomination of Gudul deals combat damage to a player, you may draw a card. If you do, discard a card."));
            magic.AddEdition(edition);
            */
            
            Console.WriteLine("Games:");
            PrintAll<Game>();

            //ClassExtension.GetAll<Game>().First().Editions.First().CardList.RemoveCard(1);

            Console.WriteLine("\nCards:");
            foreach (var card in ClassExtension.GetAll<Card>())
            {
                if (card.IsPublished == null)
                {
                    Console.WriteLine("Card {0} publish status is not set. Please chose if the card should be published? Y/N/I(gnore)", card.Name);
                    var line = Console.ReadLine();
                    line = line == null ? "" : line.ToUpper();
                    while (line != "Y" && line != "N" && line != "I")
                    {
                        line = Console.ReadLine();
                    }
                    switch (line)
                    {
                        case "Y":
                            card.Publish();
                            break;
                        case "N":
                            card.Hide();
                            break;
                    }
                }
                Console.WriteLine(card);
                Console.WriteLine("-------------------------------");
            }
            
            ClassExtension.SaveData();


        }
    }
}
