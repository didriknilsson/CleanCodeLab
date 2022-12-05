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
        public void OutputList(List<string> output);
    }
}
