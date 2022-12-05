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
            games.Add("MooGame");
            games.Add("MasterMind");
            return games;
        }
        public bool CheckIfGameExists(string chosenGame)
        {
            List<string> games = GetGames();
            string game = games.Where(x => x.ToLower() == chosenGame).FirstOrDefault();
            if (game == null)
                return false;
            else
                return true;
        }
        public IGame CreateGame(string type, IUI ui)
        {
            switch(type)
            {
                case "moogame":
                    return new MooGame(ui);          
                case "mastermind":
                    throw new NotImplementedException("Game does not exist");
                default:
                    throw new Exception();
            }

        }
    }
}
