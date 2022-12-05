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
        //private IDataHandler _dataHandler;
        //private IDataConverter _dataConverter;
        private GameFactory _gameFactory;
        private IGame _game;
        private string _playerName { get; set; }


        public GamesController(IUI ui, GameFactory gameFactory)
        {
            _ui = ui;
            //_dataHandler = dataHandler;
            //_dataConverter = dataConverter;
            _gameFactory = gameFactory;
        }

        public void Run()
        {

            _ui.Output("Enter your user name:\n");
            _playerName = _ui.Input();
            bool keepPlaying = true;
            bool gameExists = false;
            string chosenGame = "";
            while(keepPlaying)
            {
                _ui.Output("Choose a game to play:\n");
                _ui.OutputList(_gameFactory.GetGames());
                _ui.Output("Please type the name of the game you wish to play");
                while(!gameExists)
                {
                    chosenGame = _ui.Input().ToLower();
                    gameExists = _gameFactory.CheckIfGameExists(chosenGame);
                }

                _game = _gameFactory.CreateGame(chosenGame, _ui);
                int numberOfGuesses = _game.PlayGame();
                //_dataHandler.SaveScore(_playerName, numberOfGuesses, chosenGame);
                // _dataHandler.GetScores();
               
                _ui.Output($"Correct, it took {numberOfGuesses} guesses \n Do you want to play a game again? yes/no");
                string playerChoice = _ui.Input();
                if(playerChoice.ToLower() == "no")
                    keepPlaying = false;
            }
        }
    }
}
