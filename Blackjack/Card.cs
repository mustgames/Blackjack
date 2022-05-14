namespace Blackjack
{
    public class Card
<<<<<<< HEAD
    {
        protected int value;
        protected string suite;
        protected bool isAce;
=======
    { // card is a base class for all cards. normal cards set their values manualy in the CreateDeck() method.
        public int value;
        public string suite;
        public bool isAce;
>>>>>>> 602baa3c1bc80eba280eec4eb5b79659f9889483
        public virtual string GetCardString()
        { // returns a string displaying all of the cards information to the player
            return value + " of " + suite;
        }
        public void SetValue(int i)
        {
            value = i;
        }
        public void SetSuite(string s)
        {
            suite = s;
        }
        public void SetAce(bool b)
        {
            isAce = b;
        }
        public int GetCardValue(){
            return value;
        }
        public bool GetCardIsAce()
        {
            return isAce;
        }
    }
}