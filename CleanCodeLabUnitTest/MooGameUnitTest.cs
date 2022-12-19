using CleanCodeLab;
using CleanCodeLab.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CleanCodeLabUnitTest
{
    [TestClass]
    public class MooGameUnitTest
    {
        Moo? _moo;
        string _playerGuess = "";
        [TestInitialize]
        public void MooGameTestInitialize()
        {
            FileDataHandler _dataHandler = new FileDataHandler();
            IUI ui = new ConsoleIO();
            _moo = new Moo(ui);
            _playerGuess = "1234";
        }

        [TestMethod()]
        public void MooGameTargetToGuessIsFourDigits()
        {
            _moo!.CreateTargetToGuess();
            StringAssert.Matches(_moo._targetToGuess, new Regex(@"^\d{4}$")); 
        }
        [TestMethod()]
        public void MooGameCheckedGuessReturnsBOrC()
        {
            _moo!._targetToGuess = "3456";
            StringAssert.Matches(_moo.CheckGuess(_playerGuess), new Regex(@"^[BC,]+$"));
        }
        [TestMethod()]
        public void TestMooGameShouldGameContiune()
        {
            _moo!._targetToGuess = "1234";
            Assert.AreEqual(_moo.ShouldGameContinue(_playerGuess), false);
        }
    }
}