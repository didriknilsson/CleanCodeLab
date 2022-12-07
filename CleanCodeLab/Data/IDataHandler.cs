using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Data
{
    public interface IDataHandler
    {
        public List<PlayerData> GetAllScores(string chosenGame);
        public void SavePlayersScore(string Name, int numberOfGuesses, string chosenGame);

    }
}
