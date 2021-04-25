using BaccaratGame;
using System;

namespace Baccarat
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player = new Player("Mario");
            IDeck deck = new Deck();
            while (true)
            {
                ICoup coup = new Coup(deck);
                new CoupManager(player, coup);
            }
        }
    }
}
