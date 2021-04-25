using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    /// <summary>
    /// <para>A french deck card.</para>
    /// 
    /// <para>Each card have the following fields: Suit and Rank.</para>
    /// <para>Cards can be summed up returning a intenger value, being the total score as defined by the rule of Baccarat.</para>
    /// 
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// In Baccarat the total value of two cards, is the module of the sum of their rank.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int operator +(Card a, Card b)
        {
            return ((int)a.Rank + (int)b.Rank) % 10;
        }

        /// <summary>
        /// The suit of the card (spades, diamond, clubs, hearts)
        /// </summary>
        public CardSuit Suit { get; }

        /// <summary>
        /// The rank of the card. May be any of the following: a number from 2 to 10, or a Jack, Queen, King, Ace.
        /// </summary>
        public CardRank Rank { get; }

        /// <summary>
        /// A french deck card.
        /// </summary>
        /// <param name="suit">The suit of the card (spades, diamond, clubs, hearts)</param>
        /// <param name="rank">The rank of the card. May be any of the following: a number from 2 to 10, or a Jack, Queen, King, Ace.</param>
        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override String ToString()
        {
            return $"{Rank} of {Suit}";
        }

    }
}
