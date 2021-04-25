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
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerTest()
        {
            IPlayer instance = new Player("MockName");
            string name = instance.Name;
            Assert.AreEqual(name, "MockName");
            int credit = instance.Credit;
            Assert.AreEqual(credit, 10000);
        }

        [TestMethod()]
        public void addCreditTest()
        {
            IPlayer instance = new Player("MockName");
            int credit1 = instance.addCredit(500);
            Assert.AreEqual(credit1, 10500);
            Assert.AreEqual(instance.Credit, 10500);
            int credit2 = instance.addCredit(200);
            Assert.AreEqual(credit2, 10700);
            Assert.AreEqual(instance.Credit, 10700);
        }

        [TestMethod()]
        public void SubtractCreditTest()
        {
            IPlayer instance = new Player("MockName");
            int credit1 = instance.SubtractCredit(400);
            Assert.AreEqual(credit1, 9600);
            Assert.AreEqual(instance.Credit, 9600);
            int credit2 = instance.SubtractCredit(300);
            Assert.AreEqual(credit2, 9300);
            Assert.AreEqual(instance.Credit, 9300);
        }
    }
}