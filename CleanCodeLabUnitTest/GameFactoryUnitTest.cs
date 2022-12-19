using CleanCodeLab;
using CleanCodeLab.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLabUnitTest
{
    [TestClass]
    public class GameFactoryUnitTest
    {
        IUI _ui;
        GameFactory _gameFactory;

        [TestInitialize]
        public void MooGameTestInitialize()
        {
            _ui = new ConsoleIO(); // Denna skaps ny inför varje test, för att vara helt säker på att jag får en ny instans inför varje test
            _gameFactory = new GameFactory(_ui);
        }
        [TestMethod]
        public void CreateGamesWithGameFactory()
        {
            GameFactory gameFactory = new GameFactory(_ui);
            Assert.IsNotNull(gameFactory.GameList);
        }
        [TestMethod]
        public void TestGetGamesNames()
        { 
            List<string> result = _gameFactory.GetGameNames();
            List<string> expected = new List<string>() { "Moo","MasterMind" };
        
            CollectionAssert.AreEqual(result, expected);
        }
        [TestMethod()]        
        public void TestGetGame()
        {
            IGame? mooGame = _gameFactory.CheckIfGameExists("moo");
            IGame? mastermindGame = _gameFactory.CheckIfGameExists("mastermind");
            Assert.IsInstanceOfType(mooGame, typeof(IGame));
            Assert.IsInstanceOfType(mastermindGame, typeof(IGame));

        }

    }
}
