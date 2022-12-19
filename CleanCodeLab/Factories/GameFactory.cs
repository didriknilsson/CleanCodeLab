using CleanCodeLab.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Factories
{
    public class GameFactory
    {
        public List<IGame> GameList { get; set; } = new List<IGame>();
        public GameFactory(IUI ui)
        {
            GameList.Add(new Moo(ui));
            GameList.Add(new MasterMind(ui)); 
        }
        public List<string> GetGameNames()
        {
            List<string> names = new List<string>();

            foreach(IGame game in GameList)
            {
                names.Add(game.Name);
            }
            return names;
        }
        public IGame? CheckIfGameExists(string chosenGame)
        {
            IGame? game = GameList.Where(x => x.Name.ToLower() == chosenGame).FirstOrDefault();
            return game;
        }
    }
}
