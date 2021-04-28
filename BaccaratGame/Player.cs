using System;

namespace BaccaratGame
{
    public class Player : IPlayer
    {
        public int Credit { get; private set; } = 10000;
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public int addCredit(int quantity)
        {
            Credit += quantity;
            return Credit;
        }

        public int SubtractCredit(int quantity)
        {
            if (quantity > Credit)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Credit -= quantity;
            return Credit;
        }
    }
}
