using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    /// <summary>
    /// A coup is a round of play.
    /// </summary>
    public class Coup : ICoup
    {
        public List<ICard> BankerCards { get; } = new();
        public List<ICard> PlayerCards { get; } = new();
        public int BankerScore { get { return BankerCards.Sum(card => (int)card.Rank) % 10; } }
        public int PlayerScore { get { return PlayerCards.Sum(card => (int)card.Rank) % 10; } }
        public CoupResult Result { get; private set; } = CoupResult.Pending;

        IDeck _deck;

        public Coup(IDeck deck)
        {
            _deck = deck;
        }

        void SetResult()
        {
            if (BankerScore > PlayerScore)
            {
                Result = CoupResult.BankerWins;
            }
            else if (BankerScore == PlayerScore)
            {
                Result = CoupResult.Tie;
            }
            else
            {
                Result = CoupResult.PlayerWins;
            }
        }

        public CoupResult DoInitialDeal()
        {
            PlayerCards.Add(_deck.DealCard());
            BankerCards.Add(_deck.DealCard());
            PlayerCards.Add(_deck.DealCard());
            BankerCards.Add(_deck.DealCard());
            if (BankerScore >= 8 || PlayerScore >= 8)
            {
                SetResult();
            }
            return Result;
        }

        /// <summary>
        /// <para>If the player has an initial total of 0–5, they draw a third card.</para>
        /// <para>If the player has an initial total of 6 or 7, they stand.</para>
        /// <para>If the player stood pat, the banker regards only their own hand and acts according to the same rule as the player.</para>
        /// <para>If the player drew a third card, the banker acts according to the following more complex rules.</para>
        /// </summary>
        /// <returns></returns>
        public CoupResult SupplementaryDeal()
        {
            if (Result != CoupResult.Pending)
            {
                throw new InvalidOperationException("The coup is already ended");
            }


            if (PlayerScore <= 5)
            {
                PlayerCards.Add(_deck.DealCard());
            }

            if (PlayerCards.Count == 2 && BankerScore <= 5)
            {
                BankerCards.Add(_deck.DealCard());
            }

            if (PlayerCards.Count == 3)
            {
                ICard playerLastCard = PlayerCards[^1];
                if (BankerScore <= 2)
                {
                    BankerCards.Add(_deck.DealCard());
                }
                else if (BankerScore == 3 && playerLastCard.Rank != CardRank.Eight)
                {
                    BankerCards.Add(_deck.DealCard());
                }
                else if (BankerScore == 4 && ((int)playerLastCard.Rank >= 2 || (int)playerLastCard.Rank <= 7))
                {
                    BankerCards.Add(_deck.DealCard());
                }
                else if (BankerScore == 5 && ((int)playerLastCard.Rank >= 4 || (int)playerLastCard.Rank <= 7))
                {
                    BankerCards.Add(_deck.DealCard());
                }
                else if (BankerScore == 6 && (playerLastCard.Rank == CardRank.Six || playerLastCard.Rank == CardRank.Seven))
                {
                    BankerCards.Add(_deck.DealCard());
                }
            }
            SetResult();
            return Result;
        }
    }
}
