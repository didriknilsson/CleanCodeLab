using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public interface IUI
    {
        void Output(string output);
        string Input();
        void ExitGame();
    }
}
