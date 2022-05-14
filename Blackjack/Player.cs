namespace Blackjack
{
    public class Player
    {
        List<Card> hand = new List<Card>();
        int handValue;
        bool busted = false;
        protected string name;

        public int HandValue() // checks hands value and if to high busts 
        {
            handValue = 0;
            foreach (Card card in hand)
            {
                handValue = handValue + card.GetCardValue();
            }
            if (handValue <= 21)
            {
                return handValue;
            }
            else
            {
                foreach (Card card in hand)
                {
                    if (card.GetCardIsAce()) // safe guard since ace can be 1 or 11
                    {
                        handValue = handValue - 10;
                        Console.WriteLine("lets count that ace as a 1 now");
                    }
                }
                if (handValue <= 21)
                {
                    return handValue;
                }
                else
                {
                    Bust();
                    return handValue;
                }
            }
        }
        public string HandString()
        { // puts all cards togheter to print out the whole hand
            string returnString = " ";
            for (int i = 0; i < hand.Count; i++)
            {
                if (i != hand.Count - 1)
                {
                    returnString = returnString + hand[i].GetCardString() + ", ";
                }
                else
                {
                    returnString = returnString + hand[i].GetCardString();
                }
            }
            return returnString;
        }
        public void Hit(Card card)
        { // adds card to hand and prints its info also with cool loading dots effekt made by Carl
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(".");
                Console.Clear();
                System.Threading.Thread.Sleep(80);
                Console.WriteLine("..");
                Console.Clear();
                System.Threading.Thread.Sleep(80);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(80);
                Console.Clear();
            }
            hand.Add(card);
            Console.WriteLine(name + " got a " + card.GetCardString());
            Console.WriteLine(name + " hand is now valued at " + HandValue());
            Console.WriteLine();
            Console.WriteLine("press anything to continue");
            Console.ReadKey(true);
        }
        public void Bust()
        { // prints the correct win statement and makes sure the game continues accordingly by skipping all other play like offer hit
            if (this is Dealer && busted == false)
            {
                Console.WriteLine("Player Wins!");
                busted = true;
            }
            else
            {
                if (busted == false)
                {
                    Console.WriteLine(handValue);
                    Console.WriteLine(name + " busted and loose thier monines");
                    busted = true;
                }
            }
        }
        public void SetName(string s)
        {
            name = s;
        }
        public string GetName()
        {
            return name; 
        }
        public void ClearHand()
        {
            hand.Clear();
        }
        public void AddCard(Card card)
        {
            hand.Add(card);
        }
        public int GetHandCount()
        {
            return hand.Count();
        }
        public Card GetDrawnCard()
        {
            return hand[GetHandCount()- 1];
        }
    }
}