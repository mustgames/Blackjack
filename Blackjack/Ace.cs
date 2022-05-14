namespace Blackjack
{
    public class Ace : DressedCard
    {
      // Ace class sets its value in a constructor and has the bool isAce set to true -
      // this lets ace have special interactions like a blackjack win or being valued at either 1 or 11.
        public Ace()
        {
            value = 11;
            isAce = true;
        }
        public override string GetCardString()
        {
            return "Ace " + suite;
        }
    }
}