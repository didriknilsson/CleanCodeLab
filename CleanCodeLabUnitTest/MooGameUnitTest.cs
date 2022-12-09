using CleanCodeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CleanCodeLabUnitTest
{
    [TestClass]
    public class MooGameUnitTest
    {
        Moo mooGame = new MooGame();
        [TestMethod()]
        public void MooGameTargetToGuessIsFourDigits()
        {
            StringAssert.Matches(mooGame.CreateTargetToGuess(), new Regex(@"^\d{4}$"));
        }
    }
}