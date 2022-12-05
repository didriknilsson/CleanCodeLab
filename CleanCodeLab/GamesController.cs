using CleanCodeLab.Converters;
using CleanCodeLab.Data;
using CleanCodeLab.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class GamesController
    {
        private IUI _ui;
        private IDataHandler _dataHandler;
        private IDataConverter _dataConverter;
        private GameFactory _gameFactory;
        private IGame _game;
        private string _playerName { get; set; }



        // IUI
        // IDataHandler
        // IDataConverter
        // IGame

        public GamesController(IUI ui, IDataHandler dataHandler, IDataConverter dataConverter, GameFactory gameFactory)
        {
            _ui = ui;
            _dataHandler = dataHandler;
            _dataConverter = dataConverter;
            _gameFactory = gameFactory;
        }

        public void Run()
        {

            _ui.Output("Enter your user name:\n");
            _playerName = _ui.Input();
            while(true)
            {
                _ui.Output("Choose a game to play:\n");
                string chosenGame = _ui.Input();

                _game = _gameFactory.CreateGame(chosenGame);
                _game.CreateTargetToGuess();


                
            }
        }
    }
}
