using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public interface IGame
    {
        public string CreateTargetToGuess();
        public string CheckPlayerGuess(string playerGuess, string targetToGuess);

    }
}
