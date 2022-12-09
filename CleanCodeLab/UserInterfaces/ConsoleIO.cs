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
            Console.WriteLine(output + "\n");
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void OutputGameNames(List<string> output)
        {
            IEnumerator enumerator = output.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        public void OutputScoreBoard(List<PlayerData> output)
        {
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in output)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGamesPlayed, p.Average()));
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
