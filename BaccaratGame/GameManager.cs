using System;

namespace BaccaratGame
{
    public class GameManager : IGameManager
    {
        public IPlayer Player { get; private set; }
        public IDeck Deck { get; private set; } = new Deck();

        public void Run()
        {
            Console.WriteLine("Welcome to this game of baccarat!\n What's your name?");
            SetPlayer();

            while (true)
            {
                DoPreCoup();
                ICoup coup = new Coup(Deck);
                ICoupManager coupManager = new CoupManager(Player, coup);
                coupManager.Run();
                if (Player.Credit <= 0)
                {
                    Console.WriteLine("You are out of cash, see you next time");
                    break;
                }
                else
                {
                    Console.WriteLine("Do you you want to play again? (enter N of no, any other key for yes)");
                    string command = Console.ReadLine();
                    if (command == "N")
                    {
                        Console.WriteLine("Thank you for playing with us! Bye bye");
                        break;
                    }
                }
            }
        }

        void SetPlayer()
        {
            string name = Console.ReadLine();
            Player = new Player(name);
            Console.WriteLine($"{Player.Name}, you have {Player.Credit} of credit, enjoy!");
        }

        void DoPreCoup()
        {
            if (Deck.Count <= 7)
            {
                Console.WriteLine("The deck is ended, a new deck shall be used.");
                var burnedCard = Deck.DealCard();
                int burnedCardValue = burnedCard.Value;
                Console.WriteLine($"The burn card is a {burnedCard}.\nThus, {burnedCardValue} more card shall be burned.");
                for (int i = 0; i < burnedCardValue; i++)
                {
                    Deck.DealCard();
                }
            }
        }
    }
}
