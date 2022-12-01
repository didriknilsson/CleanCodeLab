using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class ConsoleIO : IUI
    {
        public void ExitGame()
        {
            System.Environment.Exit(0);
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
