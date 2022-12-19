using CleanCodeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabUnitTest
{
    [TestClass()]
    public class PlayerUnitTest
    {
        PlayerData player = new PlayerData("amanda", 0);
        [TestMethod()]
        public void TestTotalGuessesIsZeroOnStart()
        {
            Assert.AreEqual(0, player.TotalGuesses);
        }
        [TestMethod()]
        public void TestUpdate()
        {
            player.UpdatePlayerData(2);
            Assert.AreEqual(2, player.TotalGuesses);
        }
        [TestMethod()]
        public void TestAverageReturnsDouble()
        {
            player.TotalGuesses = 4;
            player.NumberOfGamesPlayed = 2;
            player.CalculateAverageScore();
            double result = player.AverageScore;
            Assert.IsInstanceOfType(result, typeof(double));
        }
        [TestMethod()]
        public void TestAverage()
        {
            player.TotalGuesses = 4;
            player.NumberOfGamesPlayed = 2;
            player.CalculateAverageScore();
            double result = player.AverageScore;
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void TestIsEquals()
        {
            PlayerData player2 = new PlayerData("amanda", 3);
            var result = player.Equals(player2);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsNotEquals()
        {
            PlayerData player2 = new PlayerData("didrik", 3);
            var result = player.Equals(player2);

            Assert.IsFalse(result);
        }


    }
}
