using CleanCodeLab;
using CleanCodeLab.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CleanCodeLabUnitTest
{
    [TestClass]
    public class MooGameUnitTest
    {
        Moo _moo;
        string _playerGuess = "";
        //string _targetToGuess = "";
        [TestInitialize]
        public void MooGameTestInitialize()
        {
            FileDataHandler _dataHandler = new FileDataHandler();
            IUI ui = new ConsoleIO();
            _moo = new Moo(ui);
            _playerGuess = "1234";
            //_targetToGuess = "1256";
        }

        [TestMethod()]
        public void MooGameTargetToGuessIsFourDigits()
        {
            _moo.CreateTargetToGuess();
            StringAssert.Matches(_moo._targetToGuess, new Regex(@"^\d{4}$")); 
        }
        [TestMethod()]
        public void MooGameCheckedGuessReturnsBOrC()
        {
            _moo.CreateTargetToGuess();
            StringAssert.Matches(_moo.CheckGuess(_playerGuess), new Regex(@"^[BC,]+$"));
        }
        [TestMethod()]
        public void TestMooGameShouldGameContiune()
        {            
            Assert.AreEqual(_moo.ShouldGameContinue("BBBB,"), false);
        }
    }
}