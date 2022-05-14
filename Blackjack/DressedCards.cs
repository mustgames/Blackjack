namespace Blackjack
{
    public class DressedCard : Card
<<<<<<< HEAD
    {
        private string dress;

        public void SetDress(string s)
=======
    { // dressed card only sets its suite manualy when made becasue all DressedCards have a value of 10 
        public string dress;
        public DressedCard()
>>>>>>> 602baa3c1bc80eba280eec4eb5b79659f9889483
        {
            dress = s; 
        }
        public override string GetCardString()
        { // overides the GetCardString() otherwise would return "10 of" suite instead of its dress then suite 
            return dress + " of " + suite;
        }
    }
}