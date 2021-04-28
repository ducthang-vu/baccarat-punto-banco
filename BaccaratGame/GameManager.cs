using System;

namespace BaccaratGame
{
    public class GameManager : IGameManager
    {
        IPlayer _player;
        IDeck _deck = new Deck();

        public void Run()
        {
            Console.WriteLine("Welcome to this game of baccarat!\n What's your name?");
            SetPlayer();

            while (true)
            {
                DoPreCoup();
                ICoup coup = new Coup(_deck);
                ICoupManager coupManager = new CoupManager(_player, coup);
                coupManager.Run();
                if (_player.Credit <= 0)
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
            _player = new Player(name);
            Console.WriteLine($"{_player.Name}, you have {_player.Credit} of credit, enjoy!");
        }

        void DoPreCoup()
        {
            if (_deck.Count <= 7)
            {
                Console.WriteLine("The deck is ended, a new deck shall be used.");
                var burnedCard = _deck.DealCard();
                int burnedCardValue = burnedCard.Value;
                Console.WriteLine($"The burn card is a {burnedCard}.\nThus, {burnedCardValue} more card shall be burned.");
                for (int i = 0; i < burnedCardValue; i++)
                {
                    _deck.DealCard();
                }
            }
        }
    }
}
