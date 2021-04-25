using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaccaratGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame.Tests
{
    [TestClass()]
    public class DeckTests
    {
        [TestMethod()]
        public void DealCardTest()
        {
            Deck instance = new();
            List<ICard> cards = new();
            int expectedTotal = 52 * 8;
            Assert.AreEqual(instance.Count, expectedTotal);
            for (int i = 0; i < expectedTotal; i++)
            { 
                ICard card = instance.DealCard();
                Assert.AreEqual(instance.Count, expectedTotal - i - 1);
                Assert.IsTrue(card is ICard);
                cards.Add(card);
            }

            int countSpades = cards.Where(card => card.Suit == CardSuit.Spades).Count();
            Assert.AreEqual(countSpades, 13 * 8);

            int countDiamonds = cards.Where(card => card.Suit == CardSuit.Diamonds).Count();
            Assert.AreEqual(countDiamonds, 13 * 8);

            int countClubs = cards.Where(card => card.Suit == CardSuit.Clubs).Count();
            Assert.AreEqual(countClubs, 13 * 8);

            int countHearts = cards.Where(card => card.Suit == CardSuit.Hearts).Count();
            Assert.AreEqual(countHearts, 13 * 8);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DealCardTestShouldRaiseError()
        {
            Deck instance = new();
            int expectedTotal = 52 * 8;
            Assert.AreEqual(instance.Count, expectedTotal);
            for (int i = 0; i < expectedTotal; i++)
            {
                Assert.IsTrue(instance.DealCard() is ICard);
            }
            instance.DealCard();
        }
    }
}