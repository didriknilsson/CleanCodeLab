using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public interface IGame
    {
        string Name { get; }
        public int PlayGame();
    }
}
