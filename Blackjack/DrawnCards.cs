using System;

namespace Blackjack
{
    public class DrawnCards
    { // DrawnCards keeps track of all cards outside the deck and keeps them in a dictionary
        Dictionary<string, Card> playedCards = new Dictionary<string, Card>();
        public void RememberCard(string cardString, Card card)
        {
            playedCards.Add(cardString, card);
        }
        public void CheckCard()
        { // Checks a inputed string if it matches with a value 
            Console.Clear();
            Console.WriteLine("Write the card you want to check star with its value then its suite, use a big letter in begining of suite or dress value and small letter for ( of )  (for example: 10 of Hearts");
            string input = Console.ReadLine();
            if (playedCards.ContainsKey(input))
            {
                Console.WriteLine("The card " + input + " has been played!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The card " + input + " has NOT been played");
            }
        }
        public void ClearCards()
        { // Clears cards, this methode is called when the deck is shuffled so you can keep track of the cards that are currently left in the deck
            playedCards.Clear();
        }
    }
}