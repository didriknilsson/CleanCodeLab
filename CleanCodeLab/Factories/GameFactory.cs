using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Factories
{
    public class GameFactory
    {
        public List<string> GetGames()
        {
            List<string> games = new List<string>();
            games.Add("mooGame");
            games.Add("masterMind");
            return new List<string>();
        }
        public IGame CreateGame(string type)
        {
            switch(type)
            {
                case "mooGame":
                    return new MooGame();          
                case "masterMind":
                    throw new NotImplementedException("Game does not exist");
                default:
                    throw new Exception();
            }

        }
    }
}
