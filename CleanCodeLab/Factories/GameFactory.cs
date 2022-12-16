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
        public List<IGame> _gameList { get; set; } = new List<IGame>();
        public GameFactory(IUI ui)
        {
            _gameList.Add(new Moo(ui));
            _gameList.Add(new MasterMind(ui)); 
        }
        public List<string> GetGameNames()
        {
            List<string> names = new List<string>();

            foreach(IGame game in _gameList)
            {
                names.Add(game.Name);
            }
            return names;
        }
        public IGame? CheckIfGameExists(string chosenGame)
        {
            IGame? game = _gameList.Where(x => x.Name.ToLower() == chosenGame).FirstOrDefault();
            return game;
        }
    }
}
