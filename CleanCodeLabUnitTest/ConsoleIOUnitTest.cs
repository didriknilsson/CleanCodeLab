using CleanCodeLab;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            // Set up test input
            string testInput = "test input";

            // Set up the test input
            using (StringReader reader = new StringReader(testInput))
            {
                Console.SetIn(reader);

                // Call the method that reads from the console
                string actualOutput = ui.Input();

                // Assert that the expected output and actual output are the same
                Assert.AreEqual(testInput, actualOutput);
            }
        }
        [TestMethod]
        public void TestWritingToConsole()
        {
            // Set up test output
            string expectedOutput = "test output";

            // Set up the test output
            using (StringWriter writer = new StringWriter())
            {
                Console.SetOut(writer);
                
                // Call the method that writes to the console
                ui.Output("test output");

                // Get the actual output
                string actualOutput = writer.ToString();

                // Assert that the expected output and actual output are the same
                Assert.AreEqual(expectedOutput, actualOutput.TrimEnd());
            }
        }
    }
}
