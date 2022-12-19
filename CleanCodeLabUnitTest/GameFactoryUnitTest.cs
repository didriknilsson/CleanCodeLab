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
        IUI ui;
        GameFactory gameFactory;

        [TestInitialize]
        public void MooGameTestInitialize()
        {
            ui = new ConsoleIO();
            gameFactory = new GameFactory(ui);

        }
        [TestMethod]
        public void CreateGamesWithGameFactory()
        {
            GameFactory gameFactory = new GameFactory(ui);
            Assert.IsNotNull(gameFactory.GameList);
        }
        [TestMethod]
        public void TestGetGamesNames()
        { 
            List<string> result = gameFactory.GetGameNames();
            List<string> expected = new List<string>() { "Moo","MasterMind" };
        
            CollectionAssert.AreEqual(result, expected);
        }
        [TestMethod()]        
        public void TestGetGame()
        {
            IGame? mooGame = gameFactory.CheckIfGameExists("moo");
            IGame? mastermindGame = gameFactory.CheckIfGameExists("mastermind");
            Assert.IsInstanceOfType(mooGame, typeof(IGame));
            Assert.IsInstanceOfType(mastermindGame, typeof(IGame));

        }

    }
}
