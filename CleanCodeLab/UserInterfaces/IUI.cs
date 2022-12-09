using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public interface IUI
    {
        public void Output(string output);
        public string Input();
        public void OutputGameNames(List<string> output);
        public void OutputScoreBoard(List<PlayerData> output);
        public void Exit();

    }
}
