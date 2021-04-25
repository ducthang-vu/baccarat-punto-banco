using System;
using System.Collections.Generic;

namespace BaccaratGame
{
    public class Deck : IDeck
    {
        /// <summary>
        /// The number of cards in the deck.
        /// </summary>
        public int Count { get { return _cards.Count; } }
        List<ICard> _cards = new List<ICard>();
        Random _rng = new Random();

        /// <summary>
        /// A Deck made of 8 standard french deck (52 * 8 cards). All cards are already shuffled.
        /// </summary>
        public Deck()
        {
            for (int i = 0; i < 8; i++)
            {
                SetCardsWithBasicDeck();
                Shuffle();
            }
        }

        void SetCardsWithBasicDeck()
        {
            var suits = Enum.GetValues(typeof(CardSuit));
            var ranks = Enum.GetNames(typeof(CardRank));
            foreach (CardSuit suit in suits)
            {
                foreach (string rank in ranks)
                {
                    CardRank rankVal = (CardRank)Enum.Parse(typeof(CardRank), rank);
                    _cards.Add(new Card(suit, rankVal));
                }
            }
        }

        /// <summary>
        /// Implements Fisher–Yates shuffle algorithm.
        /// </summary>
        void Shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                ICard tempCard = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = tempCard;
            }
        }

        /// <summary>
        /// Deal one card, and remove it from the deck.
        /// </summary>
        /// <returns>The dealt card.</returns>
        public ICard DealCard()
        {
            ICard card = _cards[^1];
            _cards.RemoveAt(_cards.Count - 1);
            return card;
        }
    }
}
