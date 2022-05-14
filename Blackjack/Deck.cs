
namespace Blackjack
{
    public class Deck
    {
        List<Card> deckOrder = new List<Card>();
        Queue<Card> deckUnOrder = new Queue<Card>();
        Random random = new Random();

        private string[] suites = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private string[] dresses = { "Jack", "Queen", "King", };

        public Deck() // room for improvement, wrote like this in case I would want to use the CreateDeck() methode to suffle the deck but I could have just put the deck in 
        {
            CreateDeck();
        }
        public void CreateDeck()
        {
            deckUnOrder.Clear();
            foreach (string suites in suites) // creates all cards form 2-10 in diffrent suites
            {
                for (int i = 2; i < 11; i++)
                {
                    var card = new Card ();
                    card.SetValue(i);
                    card.SetSuite(suites);
                    card.SetAce(false);
                    deckOrder.Add(card);
                }
                foreach (string dresses in dresses) // creates all dressed cards in diffrent suites thier value is always 10 and is set in their constructor
                {
                    var dressedCard = new DressedCard ();
                    dressedCard.SetDress(dresses);
                    deckOrder.Add(dressedCard);
                }
                var ace = new Ace (); // creates all aces in diffrent suites thier value is set in constructor and then handeld by Player HandValue()
                deckOrder.Add(ace);

            }
            for (int i = 0; i < 52; i++)  // shuffels the cards
            {
                int x = random.Next(0, deckOrder.Count);
                deckUnOrder.Enqueue(deckOrder[x]);
                deckOrder.RemoveAt(x);
            }
        }
        public Card GetCard()
        {
            return deckUnOrder.Dequeue();
        }
        public bool NeedShuffle()
        {
            if(deckUnOrder.Count < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}