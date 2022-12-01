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
        Player player = new Player();
        [TestMethod()]
        public void TotalGuessesIsZeroOnStart()
        {
            Assert.AreEqual(0, player.TotalGuesses);
        }
        [TestMethod()]
        public void NumberOfGuessesIsZeroOnStart()
        {
            Assert.AreEqual(0, player.NumberOfGuesses);
        }
    }
}
