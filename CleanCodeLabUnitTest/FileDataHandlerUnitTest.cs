using CleanCodeLab;
using CleanCodeLab.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabUnitTest
{
    [TestClass()]
    public class FileDataHandlerUnitTest
    {
        FileDataHandler _dataHandler = new FileDataHandler();

        [TestMethod()]
        public void TestSavePlayersScoreAndGetLeaderBoard()
        {
            _dataHandler.SavePlayersScore("Amanda", 3, "test");
            _dataHandler.SavePlayersScore("Ulf", 5, "test");
            _dataHandler.SavePlayersScore("Oscar", 3, "test");
            _dataHandler.SavePlayersScore("Amanda", 5, "test");
            _dataHandler.SavePlayersScore("Amanda", 2, "test");

            List<PlayerData> result = _dataHandler.GetLeaderBoard("test");
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(result[0].Name, "Oscar");
        }

        [TestMethod()]
        public void TestGetScoreFromEmptyFile()
        {           
            List<PlayerData> result = _dataHandler.GetLeaderBoard("testEmpty");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void TestScoreParserPlayerName()
        {
            string testscore = "amanda#&#3";
            PlayerData actualPlayerData = _dataHandler.ParsePlayerAndScore(testscore);
            PlayerData expectedPlayerData = new PlayerData("amanda", 3);
            Assert.AreEqual(expectedPlayerData.Name, actualPlayerData.Name);
        }
        [TestMethod()]
        public void TestScoreParserPlayerScore()
        {
            string testscore = "amanda#&#3";
            PlayerData actualPlayerData = _dataHandler.ParsePlayerAndScore(testscore);
            PlayerData expectedPlayerData = new PlayerData("amanda", 3);
            Assert.AreEqual(expectedPlayerData.TotalGuesses, actualPlayerData.TotalGuesses);
        }
        [DataTestMethod()]
        [DataRow("amanda#&#3", "amanda", 3)]
        public void TestScoreParserPlayer(string testscore, string expectedPlayerName, int expectedTotalGuesses)
        {
            PlayerData actualPlayerData = _dataHandler.ParsePlayerAndScore(testscore);
            PlayerData expectedPlayerData = new PlayerData(expectedPlayerName, expectedTotalGuesses);
            Assert.AreEqual(expectedPlayerData.Name, actualPlayerData.Name);
            Assert.AreEqual(expectedPlayerData.TotalGuesses, actualPlayerData.TotalGuesses);
        }
        [TestMethod()]
        public void TestGetScoreListFirstPosition()
        {
            _dataHandler.SavePlayersScore("Amanda", 3, "mootest");
            _dataHandler.SavePlayersScore("Ulf", 5, "mootest");
            _dataHandler.SavePlayersScore("Oscar", 3, "mastermindtest");
            _dataHandler.SavePlayersScore("Amanda", 5, "mootest");
            _dataHandler.SavePlayersScore("Didrik", 5, "mastermindtest");
            _dataHandler.SavePlayersScore("Didrik", 2, "mootest");
            _dataHandler.SavePlayersScore("Didrik", 2, "mastermindtest");

            StreamReader mooScoresStreamReader = new StreamReader("mootest.txt");
            StreamReader mastermindScoresStreamReader = new StreamReader("mastermindtest.txt");
            List<string> mooScoreList = _dataHandler.GetScoreList(mooScoresStreamReader);
            List<string> masterMindScoreList = _dataHandler.GetScoreList(mastermindScoresStreamReader);

            //Assert.AreEqual(4, mooScoreList.Count);
            //Assert.AreEqual(3, masterMindScoreList.Count);

            Assert.AreEqual(mooScoreList[0], "Amanda#&#3");
            Assert.AreEqual(masterMindScoreList[0], "Oscar#&#3");
        }
        [TestMethod]
        public void TestConvertToLeaderBoard()
        {
            List<string> scoreList = new List<string>() {"didrik#&#2","amanda#&#2", "amanda#&#1" };
            List<PlayerData> resultLeaderBoard = _dataHandler.ConvertToLeaderBoard(scoreList);
            List<PlayerData> expectedLeaderBoard = new List<PlayerData>();
            PlayerData player1 = new PlayerData("amanda", 2);
            player1.AddGameResult(1);
            PlayerData player2 = new PlayerData("didrik", 2);
            expectedLeaderBoard.Add(player1);
            expectedLeaderBoard.Add(player2);

            CollectionAssert.AreEqual(expectedLeaderBoard, resultLeaderBoard);
        }
        [TestMethod]
        public void TestCalculateLeaderBoard()
        {
            List<PlayerData> scoreBoard = new List<PlayerData>();
            PlayerData player1 = new PlayerData("amanda", 2);
            player1.AddGameResult(1);
            PlayerData player2 = new PlayerData("didrik", 2);
            PlayerData player3 = new PlayerData("oscar", 5);
            player3.AddGameResult(2);
            scoreBoard.Add(player3);
            scoreBoard.Add(player2);
            scoreBoard.Add(player1);

            List<PlayerData> expectedLeaderBoard = new List<PlayerData>();
            //PlayerData excpectedPlayer1 = new PlayerData("amanda", 2);
            //excpectedPlayer1.AddGameResult(1);
            //PlayerData excpectedPlayer2 = new PlayerData("didrik", 2);
            //PlayerData excpectedPlayer3 = new PlayerData("oscar", 5);
            //excpectedPlayer3.AddGameResult(2);
            //expectedLeaderBoard.Add(excpectedPlayer1);
            //expectedLeaderBoard.Add(excpectedPlayer2);
            //expectedLeaderBoard.Add(excpectedPlayer3);
            expectedLeaderBoard.Add(player1);
            expectedLeaderBoard.Add(player2);
            expectedLeaderBoard.Add(player3);

            List<PlayerData> actualLeaderBoard = _dataHandler.CalculateLeaderBoard(scoreBoard);

            CollectionAssert.AreEqual(expectedLeaderBoard, actualLeaderBoard);
        }
    }
}
