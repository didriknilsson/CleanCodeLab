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

        public void OutputScoreBoard(List<PlayerData> output)
        {
            output.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in output)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGamesPlayed, p.Average()));
            }
        }
    }
}
