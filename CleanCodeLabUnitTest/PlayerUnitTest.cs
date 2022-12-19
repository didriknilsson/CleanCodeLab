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
        PlayerData? _player;
        [TestInitialize]
        public void PlayerTestInitialize()
        {
            _player = new PlayerData("amanda", 0);
        }
        [TestMethod()]
        public void TestTotalGuessesIsZeroOnStart()
        {
            Assert.AreEqual(0, _player!.TotalGuesses);
        }
        [TestMethod()]
        public void TestAddGameResult()
        {
            _player!.AddGameResult(2);
            Assert.AreEqual(2, _player.TotalGuesses);
        }
        [TestMethod()]
        public void TestCalculateAverageScore()
        {
            _player!.TotalGuesses = 4;
            _player.NumberOfGamesPlayed = 2;
            _player.CalculateAverageScore();
            double result = _player.AverageScore;
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void TestIsEquals()
        {
            PlayerData player2 = new PlayerData("amanda", 3);
            var result = _player!.Equals(player2);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestIsNotEquals()
        {
            PlayerData player2 = new PlayerData("didrik", 3);
            var result = _player!.Equals(player2);

            Assert.IsFalse(result);
        }


    }
}
