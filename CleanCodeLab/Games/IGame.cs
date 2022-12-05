using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public interface IGame
    {
        public int PlayGame();
        public void CreateTargetToGuess();
        public string CheckGuess(string guess);
        public bool ShouldGameContinue(string result);

    }
}
