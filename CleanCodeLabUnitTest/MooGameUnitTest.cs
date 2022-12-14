using CleanCodeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CleanCodeLabUnitTest
{
    [TestClass]
    public class MooGameUnitTest
    {
        //[TestMethod()]
        //public void MooGameTargetToGuessIsFourDigits()
        //{
        //    IUI ui = new ConsoleIO();
        //    Moo moo = new Moo(ui);
        //    moo.
        //    StringAssert.Matches(moo.CreateTargetToGuess(), new Regex(@"^\d{4}$"));
        //}
        [TestMethod()]
        public void TestScoreParserPlayerName()
        {
            string testscore = "amanda#&#3";
            PlayerData actualPlayerData = FileDataHandler.ParseScore(testscore);
            PlayerData expectedPlayerData = new PlayerData("amanda", 3);
            Assert.AreEqual(expectedPlayerData.Name, actualPlayerData.Name);            
        }
        [TestMethod()]
        public void TestScoreParserPlayerScore()
        {
            string testscore = "amanda#&#3";
            PlayerData actualPlayerData = FileDataHandler.ParseScore(testscore);
            PlayerData expectedPlayerData = new PlayerData("amanda", 3);
            Assert.AreEqual(expectedPlayerData.TotalGuesses, actualPlayerData.TotalGuesses);
        }
        [DataTestMethod()]
        [DataRow("amanda#&#3","amanda",3)]
        [DataRow("ama#&#nda#&#3", "ama", 3)]
        public void TestScoreParserPlayer(string testscore, string expectedPlayerName, int expectedTotalGuesses)
        {
  
            PlayerData actualPlayerData = FileDataHandler.ParseScore(testscore);
            PlayerData expectedPlayerData = new PlayerData(expectedPlayerName, expectedTotalGuesses);
            Assert.AreEqual(expectedPlayerData.Name, actualPlayerData.Name);
            Assert.AreEqual(expectedPlayerData.TotalGuesses, actualPlayerData.TotalGuesses);
        }

    }
}