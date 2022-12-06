using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Factories
{
    public class ScoreFileFactory
    {
        public static string GetFilePath(string game)
        {
            switch (game)
            {
                case "moogame":
                    return "moogame.txt";
                case "mastermind":
                    throw new NotImplementedException("Game does not exist");
                default:
                    throw new Exception();
            }

        }
    }
}
