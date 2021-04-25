using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaccaratGame.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void CardTest()
        {
            Card instance = new(CardSuit.Hearts, CardRank.Eight);
            Assert.AreEqual(instance.Suit, CardSuit.Hearts);
            Assert.AreEqual(instance.Rank, CardRank.Eight);
            Assert.AreEqual((int)instance.Rank, 8);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Card instance = new(CardSuit.Hearts, CardRank.Eight);
            string result = instance.ToString();
            Assert.AreEqual(result, "Eight of Hearts");
        }

        [TestMethod()]
        public void AdditionTest()
        {
            Card instance1 = new(CardSuit.Hearts, CardRank.Eight);
            Card instance2 = new(CardSuit.Clubs, CardRank.Five);
            int result1 = instance1 + instance2;
            Assert.AreEqual(result1, 3);

            Card instance3 = new(CardSuit.Hearts, CardRank.Three);
            Card instance4 = new(CardSuit.Clubs, CardRank.Four);
            int result2 = instance3 + instance4;
            Assert.AreEqual(result2, 7);

            Card instance5 = new(CardSuit.Hearts, CardRank.Five);
            Card instance6 = new(CardSuit.Clubs, CardRank.Five);
            int result3 = instance5 + instance6;
            Assert.AreEqual(result3, 0);

            Card instance7 = new(CardSuit.Hearts, CardRank.Eight);
            Card instance8 = new(CardSuit.Clubs, CardRank.Jack);
            int result4 = instance7 + instance8;
            Assert.AreEqual(result4, 8);

        }
    }
}