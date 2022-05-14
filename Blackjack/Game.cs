namespace Blackjack
{
    public class Game // game classen is inspired by the game manger role in many other game projects ive seen where it is a object that has all gamelogic not connected to a specific object
    {
        bool gameRunning;
        bool win;
        Deck deck = new Deck();
        List<Player> players = new List<Player>();
        Player player = new Player();
        Dealer dealer = new Dealer();
        DrawnCards drawnCards = new DrawnCards();
        public void Intro()
        { // intro gives player some basic info and lets them input a string name, dosnt let them input nothing and Dealer since the Dealer has the name dealer
            players.Add(player);
            Console.WriteLine("Welcome to Blackjack");
            Console.WriteLine("What is your name gambling man!");
            while (true)
            {
                try
                {
                    player.SetName( Console.ReadLine());
                    if(player.GetName() != "" && player.GetName() != "nothing" && player.GetName() != "Nothing"&& player.GetName() != "NOTHING")

                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Your name can't be nothing or Dealer");
                    }
                }
                catch (System.NullReferenceException)
                {
                    System.Console.WriteLine("Your name can't be nothing");
                    throw;
                }
            }
            Console.WriteLine();
            Console.WriteLine(player.GetName() + " press anything exept power off or alt + F4 to start loosing monies"); // other Malte thought instructions where to unclear
            gameRunning = true;
            win = false;
            Console.ReadKey(true);
            Console.Clear();
        }
        public void Deal()
        { // Deal gives out the starting hand 2 cards for each player and 1 for dealer also checks for a blackjackwin 
            foreach (Player player in players) // removes all old cards in case of another round
            {
                if (player.GetHandCount() > 0)
                {
                    player.ClearHand();
                    dealer.ClearHand();
                }
            }
            if (deck.NeedShuffle())
            {
                deck.CreateDeck();
                Console.WriteLine("Time to shuffle deck");
                drawnCards.ClearCards();
            }
            foreach (Player player in players)
            {
                player.AddCard(deck.GetCard());
                System.Console.WriteLine(player.GetHandCount());
                Console.ReadLine();
                drawnCards.RememberCard(player.GetNameOfDrawnCard() ,player.GetDrawnCard());

                player.AddCard(deck.GetCard());
                    drawnCards.RememberCard(player.GetNameOfDrawnCard() ,player.GetDrawnCard());

                if (player.HandValue() == 21)
                {
                    BlackjackWin();
                }
            }
            dealer.AddCard(deck.GetCard());
                    drawnCards.RememberCard(player.GetNameOfDrawnCard() ,player.GetDrawnCard());


        }
        public void OfferHit()
        {// offer hit first checks if the player has already won in case of blackjack then player can input y or n to accept or decline reciving another card
            while (true && player.HandValue() < 22 && dealer.HandValue() < 22 && gameRunning == true && win == false)
            {
                Console.WriteLine("Dealer has" + dealer.HandString());
                Console.WriteLine(player.GetName() + " hand is a" + player.HandString());
                Console.WriteLine(player.GetName() + " hand has a value of " + player.HandValue());
                Console.WriteLine();
                Console.WriteLine("want card? press [y] for yes or [n] for no");
                string input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    player.Hit(deck.GetCard());
                    drawnCards.RememberCard(player.GetNameOfDrawnCard() ,player.GetDrawnCard());
                }
                else if (input == "n" || input == "N")
                {
                    Console.WriteLine("Staying are we");
                    break;
                }
                else
                {
                    Console.WriteLine("you input wrong. Only [y] for yes or [n] for no, I want no more of your silly games");
                }
            }
        }
        public void Reveal()
        { // after the player has gotten as many cards as they want the dealer draws until either the player or the dealer wins, player wins if dealer busts wich is check for by the hit methode inherited from Player.cs 
            if (dealer.HandValue() < 22 && player.HandValue() < 22 && gameRunning == true && win == false)
            {
                while (true)
                {
                    if (dealer.HandValue() > player.HandValue() && dealer.HandValue() < 22 && win == false)
                    {
                        DealerWin();
                        break;
                    }
                    else if (dealer.HandValue() > 16 && player.HandValue() > dealer.HandValue() && win == false)
                    {
                        System.Console.WriteLine("dealer has to stay");
                        PlayerWin();
                        break;
                    }
                    else if (dealer.HandValue() > 21)
                    {
                        break;
                    }
                    dealer.Hit(deck.GetCard());
                    drawnCards.RememberCard(dealer.GetNameOfDrawnCard(), dealer.GetDrawnCard());

                }
            }
        }
        public bool RematchOption()
        { // simple input y or n if you want to continue playing game will return to Deal() if y
            win = false;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("want play again? press [y] for yes or [n] for no");
                string input = Console.ReadLine();
                if (input == "n" || input == "N")
                {
                    gameRunning = false;
                    return false;
                }
                else if (input == "y" || input == "Y")
                {
                    return true;
                }
            }
        }
        public void ShowPlayedCardsOption()
        { // gives players an option to call the ListPlayedCards() method to see all cards played in all games so far
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Do you want too check if a specific card has been played? [y] for yes or [n] for no");
                string input = Console.ReadLine();
                if (input == "n" || input == "N")
                {
                    break;
                }
                else if (input == "y" || input == "Y")
                {
                    drawnCards.CheckCard();
                    break;
                }
            }
        }
        public void PlayerWin()
        { // Beacuse player can win at diffrent places this methode just stores a win which the other methodes will deal with accordingly so the game running loop can continue correctly
            if (win == false)
            {
                Console.WriteLine("Player Wins!");
                win = true;
            }
        }
        public void DealerWin()
        { // Is called if dealer picks up additional cards and has a higher hand value then the player
            if (win == false)
            {
                Console.WriteLine("Dealer Wins yay!!! i get the monies");
                win = true;
            }
        }
        public void BlackjackWin()
        {
            if (win == false)
            {
                Console.WriteLine(player.GetName() + " hand is a" + player.HandString());
                Console.WriteLine("Player Wins dubble with a black jack win!");
                win = true;
            }
        }
    }
}