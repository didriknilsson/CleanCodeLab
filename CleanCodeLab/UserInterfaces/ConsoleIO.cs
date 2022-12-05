using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class ConsoleIO : IUI
    {
        public void Output(string output)
        {
            Console.WriteLine(output);
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void OutputList(List<string> output)
        {
            IEnumerator enumerator = output.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
