using System;

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
            return (a.Value + b.Value) % 10;
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
        /// The value of the card, being either the numeric value, or 1 for an ace, or 0 for face cards.
        /// </summary>
        public int Value 
        { 
            get 
            {
                return Rank.Value();
            } 
        }

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
