using Blackjack;

Game game = new Game();
game.Intro();
bool gameRunning = true;

// this script is structured to show a clear outline of when events take place
// therfore I have moved the actual code of the events to methodes in the game class. 

while (gameRunning == true)
{
    game.Deal();
    game.OfferHit();
    game.Reveal();
    game.ShowPlayedCardsOption();
    gameRunning = game.RematchOption();
}
Console.WriteLine();
Console.WriteLine("Bye bye take ur monies other day! (press anything to exit)");
Console.ReadKey();