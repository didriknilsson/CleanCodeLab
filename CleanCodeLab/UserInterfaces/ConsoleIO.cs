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

        public void OutputGameNames(List<string> names)
        {
            IEnumerator enumerator = names.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        public void OutputLeaderBoard(List<PlayerData> leaderBoard)
        {
            Console.WriteLine("Player   games average");
            foreach (PlayerData player in leaderBoard)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGamesPlayed, player.AverageScore));
            }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
