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
        private IGameDataHandler _dataHandler;
        private GameFactory _gameFactory;
        private IGame? _gameToPlay;


        public GamesController(IUI ui, GameFactory gameFactory, IGameDataHandler dataHandler)
        {
            _ui = ui;
            _dataHandler = dataHandler;
            _gameFactory = gameFactory;
        }

        public void Run()
        {
            string playerName;

            _ui.Output("Enter your user name:");
            playerName = _ui.Input().Trim();
            bool keepPlaying = true;
            do
            {
                string chosenGame;
                _ui.Output("Avalible game(s):");
                _ui.OutputGameNames(_gameFactory.GetGameNames());
                _ui.Output("Please type the name of the game you wish to play:");
                do
                {
                    chosenGame = _ui.Input().ToLower().Trim();
                    _gameToPlay = _gameFactory.CheckIfGameExists(chosenGame);
                    if (_gameToPlay == null)
                        _ui.Output($"There's no game called {chosenGame}, please try again.");
                } while (_gameToPlay == null);

                int numberOfGuesses = _gameToPlay!.PlayGame();
                _dataHandler.SavePlayersScore(playerName, numberOfGuesses, chosenGame);
                List<PlayerData> scoreBoard = _dataHandler.GetLeaderBoard(chosenGame);
                _ui.OutputLeaderBoard(scoreBoard);

                _ui.Output($"Correct, it took {numberOfGuesses} guesses.");
                _ui.Output("Do you want to play a game again? yes/no");
                string playerChoice = _ui.Input();
                if (playerChoice.ToLower().Trim() == "no")
                {
                    keepPlaying = false;
                    _ui.Exit();
                }
                _gameToPlay = null;
            }while (keepPlaying);
        }
    }
}
