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
        FileDataHandler _fileDataHandler = new FileDataHandler();

        [TestMethod()]
        public void TestSavePlayersScore()
        {
            File.WriteAllText("test.txt", "");
            _fileDataHandler.SavePlayersScore("Amanda", 3, "test");
            _fileDataHandler.SavePlayersScore("Ulf", 5, "test");
            _fileDataHandler.SavePlayersScore("Oscar", 3, "test");
            _fileDataHandler.SavePlayersScore("Amanda", 5, "test");
            _fileDataHandler.SavePlayersScore("Amanda", 2, "test");

            StreamReader scoresStreamReader = new StreamReader("test.txt");
            List<string> actualScoreData = new List<string>();

            while (scoresStreamReader.ReadLine() is { } line)
            {
                actualScoreData.Add(line);
            }
            scoresStreamReader.Close();

            List<string> expectedResult = new List<string>() {$"Amanda{_fileDataHandler.seperator}3",
                $"Ulf{_fileDataHandler.seperator}5",$"Oscar{_fileDataHandler.seperator}3",
                $"Amanda{_fileDataHandler.seperator}5", $"Amanda{_fileDataHandler.seperator}2"};

            CollectionAssert.AreEqual(expectedResult, actualScoreData);

        }
        [TestMethod]
        public void TestGetLeaderBoard()
        {
            File.WriteAllText("test.txt", "");

            StreamWriter output = new StreamWriter("test.txt", append: true);
            output.WriteLine("Amanda" + _fileDataHandler.seperator + 4);
            output.WriteLine("Ulf" + _fileDataHandler.seperator + 5);
            output.WriteLine("Oscar" + _fileDataHandler.seperator + 3);
            output.WriteLine("Amanda" + _fileDataHandler.seperator + 6);
            output.WriteLine("Amanda" + _fileDataHandler.seperator + 5);
            output.Close();

            List<PlayerData> actualResult = _fileDataHandler.GetLeaderBoard("test");
            List<PlayerData> expectedResult = new List<PlayerData>();
            expectedResult.Add(new PlayerData("Oscar", 3));
            expectedResult.Add(new PlayerData("Ulf", 5));
            PlayerData player1 = new PlayerData("Amanda", 4);
            player1.AddGameResult(6);
            player1.AddGameResult(5);
            expectedResult.Add(player1);

            CollectionAssert.AreEqual(actualResult, expectedResult);

        }

        [TestMethod()]
        public void TestGetScoreFromEmptyFile()
        {           
            List<PlayerData> result = _fileDataHandler.GetLeaderBoard("testEmpty");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void TestScoreParserPlayerName()
        {
            string testscore = $"amanda{_fileDataHandler.seperator}3";
            PlayerData actualPlayerData = _fileDataHandler.ParsePlayerAndScore(testscore);
            PlayerData expectedPlayerData = new PlayerData("amanda", 3);
            Assert.AreEqual(expectedPlayerData.Name, actualPlayerData.Name);
        }
        [TestMethod()]
        public void TestScoreParserPlayerScore()
        {
            string testscore = $"amanda{_fileDataHandler.seperator}3";
            PlayerData actualPlayerData = _fileDataHandler.ParsePlayerAndScore(testscore);
            PlayerData expectedPlayerData = new PlayerData("amanda", 3);
            Assert.AreEqual(expectedPlayerData.TotalGuesses, actualPlayerData.TotalGuesses);
        }
        [DataTestMethod()]
        [DataRow("amanda#&#3", "amanda", 3)]
        public void TestScoreParserPlayer(string testscore, string expectedPlayerName, int expectedTotalGuesses)
        {
            PlayerData actualPlayerData = _fileDataHandler.ParsePlayerAndScore(testscore);
            PlayerData expectedPlayerData = new PlayerData(expectedPlayerName, expectedTotalGuesses);
            Assert.AreEqual(expectedPlayerData.Name, actualPlayerData.Name);
            Assert.AreEqual(expectedPlayerData.TotalGuesses, actualPlayerData.TotalGuesses);
        }
        [TestMethod()]
        public void TestGetScoreListFirstPosition()
        {
            _fileDataHandler.SavePlayersScore("Amanda", 3, "mootest");
            _fileDataHandler.SavePlayersScore("Ulf", 5, "mootest");
            _fileDataHandler.SavePlayersScore("Oscar", 3, "mastermindtest");
            _fileDataHandler.SavePlayersScore("Amanda", 5, "mootest");
            _fileDataHandler.SavePlayersScore("Didrik", 5, "mastermindtest");
            _fileDataHandler.SavePlayersScore("Didrik", 2, "mootest");
            _fileDataHandler.SavePlayersScore("Didrik", 2, "mastermindtest");

            StreamReader mooScoresStreamReader = new StreamReader("mootest.txt");
            StreamReader mastermindScoresStreamReader = new StreamReader("mastermindtest.txt");
            List<string> mooScoreList = _fileDataHandler.GetScoreList(mooScoresStreamReader);
            List<string> masterMindScoreList = _fileDataHandler.GetScoreList(mastermindScoresStreamReader);

            //Assert.AreEqual(4, mooScoreList.Count);
            //Assert.AreEqual(3, masterMindScoreList.Count);

            Assert.AreEqual(mooScoreList[0], "Amanda#&#3");
            Assert.AreEqual(masterMindScoreList[0], "Oscar#&#3");
        }
        [TestMethod]
        public void TestConvertToLeaderBoard()
        {
            List<string> scoreList = new List<string>() {"didrik#&#2","amanda#&#2", "amanda#&#1" };
            List<PlayerData> resultLeaderBoard = _fileDataHandler.ConvertToLeaderBoard(scoreList);
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
            PlayerData excpectedPlayer1 = new PlayerData("amanda", 2);
            excpectedPlayer1.AddGameResult(1);
            PlayerData excpectedPlayer2 = new PlayerData("didrik", 2);
            PlayerData excpectedPlayer3 = new PlayerData("oscar", 5);
            excpectedPlayer3.AddGameResult(2);
            expectedLeaderBoard.Add(excpectedPlayer1);
            expectedLeaderBoard.Add(excpectedPlayer2);
            expectedLeaderBoard.Add(excpectedPlayer3);

            List<PlayerData> actualLeaderBoard = _fileDataHandler.CalculateLeaderBoard(scoreBoard);

            CollectionAssert.AreEqual(expectedLeaderBoard, actualLeaderBoard);
        }
    }
}
