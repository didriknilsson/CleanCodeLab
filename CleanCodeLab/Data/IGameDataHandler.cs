using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Data
{
    public interface IGameDataHandler
    {
        public List<PlayerData> GetLeaderBoard(string chosenGame);
        public void SavePlayersScore(string name, int numberOfGuesses, string chosenGame);
    }
}
