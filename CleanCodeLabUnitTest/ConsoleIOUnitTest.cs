using CleanCodeLab;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCodeLabUnitTest
{
    [TestClass]
    public class ConsoleIOUnitTest
    {
        IUI ui = new ConsoleIO();
        
        [TestMethod]
        public void TestReadingFromConsole()
        {
            string testInput = "test input";

            using (StringReader reader = new StringReader(testInput))
            {
                Console.SetIn(reader);

                string actualOutput = ui.Input();

                Assert.AreEqual(testInput, actualOutput);
            }
        }
        [TestMethod]
        public void TestWritingToConsole()
        {
            string expectedOutput = "test output";

            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                
                ui.Output("test output");

                string actualOutput = writer.ToString();

                Assert.AreEqual(expectedOutput, actualOutput.TrimEnd());
            }
        }
        [TestMethod]
        public void TestOutputLeaderBoard()
        {
            var leaderBoard = new List<PlayerData>
            {
                new PlayerData("Didrik", 5) { NumberOfGamesPlayed = 1 },
                new PlayerData("Amanda", 8) { NumberOfGamesPlayed = 2 },
                new PlayerData("Edde", 6) { NumberOfGamesPlayed = 2 },
            };

            leaderBoard.ForEach(player => player.CalculateAverageScore());

            var expectedOutput = "Player   games average\r\n" +
                                 "Didrik       1     5,00\r\n" +
                                 "Amanda       2     4,00\r\n" +
                                 "Edde         2     3,00\r\n";

            using (var stringReader = new StringReader(""))
            using (var stringWriter = new StringWriter())
            {
                Console.SetIn(stringReader);
                Console.SetOut(stringWriter);

                ui.OutputLeaderBoard(leaderBoard);

                Assert.AreEqual(expectedOutput, stringWriter.ToString());
            }
        }
        [TestMethod]
        public void TestOutputGameNames()
        {
            // Arrange
            var names = new List<string> { "Moo", "MasterMind"};
            var expectedOutput = "Moo\r\nMasterMind\r\n";

            using (var stringReader = new StringReader(""))
            using (var stringWriter = new StringWriter())
            {
                Console.SetIn(stringReader);
                Console.SetOut(stringWriter);

                // Act
                ui.OutputGameNames(names);

                // Assert
                Assert.AreEqual(expectedOutput, stringWriter.ToString());
            }
        }
        [TestMethod]
        public void TestExitDoesExitProgram()
        {
            var mockUI = new Mock<IUI>();
            var mockConsoleIO = mockUI.Object;

            mockConsoleIO.Exit();

            mockUI.Verify(ui => ui.Exit(), Times.Once);
        }
    }
}
