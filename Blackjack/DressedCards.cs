namespace Blackjack
{
    public class DressedCard : Card
    {
        private string dress;
        // dressed card only sets its suite manualy when made becasue all DressedCards have a value of 10 

        public void SetDress(string s)

        {
            dress = s; 
        }
        public override string GetCardString()
        { // overides the GetCardString() otherwise would return "10 of" suite instead of its dress then suite 
            return dress + " of " + suite;
        }
    }
}