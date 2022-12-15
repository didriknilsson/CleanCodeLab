using CleanCodeLab;
using CleanCodeLab.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabUnitTest
{
    [TestClass()]
    public class FileDataHandlerUnitTest
    {
        IGameDataHandler _dataHandler = new FileDataHandler();

        [TestMethod()]
        public void TestSavePlayersScore()
        {
            _dataHandler.SavePlayersScore("Amanda", 3, "test");
            _dataHandler.SavePlayersScore("Ulf", 5, "test");
            _dataHandler.SavePlayersScore("Oscar", 3, "test");
            _dataHandler.SavePlayersScore("Amanda", 5, "test");
            _dataHandler.SavePlayersScore("Amanda", 2, "test");

            List<PlayerData> result = _dataHandler.GetAllUserAverageScores("test");
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(result[0].Name, "Oscar");
        }

        [TestMethod()]
        public void TestGetScoreFromEmptyFile()
        {           
            List<PlayerData> result = _dataHandler.GetAllUserAverageScores("testEmpty");
            Assert.AreEqual(0, result.Count);
        }
    }
}
