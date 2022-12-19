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
    }
}
