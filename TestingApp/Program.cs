using System;
using System.Linq;
using CardGames;
using CardGames.CardLists;
using CardGames.Social;

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
            ClassExtension.LoadData(); // Ekstensja klas - plus trwałość 

            // Odkomentować jeśli jest potrzeba wygenerować dane od nowa!!

            /*
            var cardfight = new Game("Cardfight!! Vanguard", 2012);
            var edition = new Edition(cardfight, "BT01", "Descent of the King of Knights");
            edition.CardList.AddCard(new Card("King of Knights, Alfred", "[CONT](VC):Your units cannot boost this unit."));
            edition.CardList.AddCard(new Card("Blaster Blade", "Blablabla"));
            cardfight.AddEdition(edition);
            
            var magic = new Game("Magic the gathering", 1995);
            edition = new Edition(magic, "KTK","Khanks of Tarkir", 2014);
            var card1 = new Card("Abomination of Gudul",
                "Whenever Abomination of Gudul deals combat damage to a player, you may draw a card. If you do, discard a card.");
            var card2 = new Card("Alabaster Kirin", "Flying, Vigilance");
            edition.CardList.AddCard(card1);
            edition.CardList.AddCard(card2);
            magic.AddEdition(edition);

            var testUser = new User("kelu", "123qwe", "kelostrada@gmail.com", "12345678");
            
            var deck = testUser.CreateDeck("ABC");
            deck.AddCard(1, card1, 2);
            deck.AddCard(1, card2, 3);

            var commentId = deck.AddComment("What a nice deck!", testUser);
            */

            Console.WriteLine("Enter login:");
            var login = Console.ReadLine();
            Console.WriteLine("Enter password:");
            var password = Console.ReadLine();

            var user = User.LoginUser(login, password);

            if (user == null)
            {
                Console.WriteLine("Login failed.");
                return;
            }

            Console.WriteLine("User {0} logged in. Phone: {1}, Email: {2}", user.Login, user.ContactData.Phone, user.ContactData.Email); // Atrybut złożony (user.ContactData)

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("User decks: ");

            foreach (var d in user.Decks)
            {
                Console.WriteLine(d.Name);
                foreach (var c in d.Cards)
                {
                    Console.WriteLine("{0}x {1}", c.Quantity, c.Card.Name);
                }
                Console.WriteLine("=====================");
                Console.WriteLine("Comments:");
                foreach (var c in d.Comments)
                {
                    Console.WriteLine("Author: {0}, Message: {1}", c.Author.Login, c.Description);
                }
            }

            Console.WriteLine("--------------------------------------------");
            
            Console.WriteLine("Games:");
            PrintAll<Game>();

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Edition in game Magic the Gathering by name:");
            var name = Console.ReadLine();
            var game = ClassExtension.GetAll<Game>().First(g => g.Name == "Magic the gathering");
            var ed = game.GetEdition(name);
            if (ed == null)
            {
                Console.WriteLine("No edition by name {0}", name);
            }
            else
            {
                Console.WriteLine(ed);
                if (ed.YearOfRelease == null) // Atrybut opcjonalny
                {
                    Console.WriteLine("Edition has no set year of release.");
                }
            }

            Console.WriteLine("--------------------------------------------");

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
