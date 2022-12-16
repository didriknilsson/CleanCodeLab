using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Games
{
    internal class MasterMind : IGame
    {
        public string Name { get; set; } = "MasterMind";
        private readonly IUI _ui;
        private int _numberOfGuesses;
        private string _targetToGuess = "";
        public MasterMind(IUI ui)
        {
            _ui = ui;
        }

        public string CheckGuess(string playerGuess)
        {
            //Denna måste göras om, det ska komma ut i rätt ordning vilken som är på rätt plats osv
            _numberOfGuesses++;
            if (playerGuess.Length < 4)
            {
                playerGuess += "    ";
            }
            bool isBlack;
            StringBuilder result = new StringBuilder();

            for (int targetPos = 0; targetPos < 4; targetPos++)
            {
                isBlack = false;
                for (int guessPos = 0; guessPos < 4; guessPos++)
                {
                    if (_targetToGuess[targetPos] == playerGuess[guessPos])
                    {                        
                        if (targetPos == guessPos && !isBlack)
                        {
                            result.Append('B');
                            isBlack = true;
                        }
                        else if(!isBlack)
                        {
                            result.Append('W');
                        }
                    }
                }
            }
            //var black = playerGuessCharArray
            //                .Zip(targetGuessCharArray, (guess, target) => guess == target)
            //                .Count(z => z);

            //var white = playerGuessCharArray
            //                .Intersect(targetGuessCharArray)
            //                .Sum(c =>
            //                    System.Math.Min(
            //                        targetGuessCharArray.Count(x => x == c),
            //                        playerGuessCharArray.Count(x => x == c))) - black;

            return result.ToString();
        }

        

        public void CreateTargetToGuess()
        {
            Random randomGenerator = new Random();
            string targetToGuess = "";
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = randomGenerator.Next(6).ToString();
                targetToGuess = targetToGuess + randomDigit;
            }
            _targetToGuess = targetToGuess;
        }

        public int PlayGame()
        {
            _numberOfGuesses = 0;
            bool continueGame;
            _ui.Output("New game:");
            CreateTargetToGuess();
            Console.WriteLine("For practice, number is: " + _targetToGuess); // DENNA SKA BORT INNAINLÄMNING

            do
            {
                string playerGuess = _ui.Input().Trim();
                string blacksAndWhites = CheckGuess(playerGuess);
                _ui.Output(blacksAndWhites);
                continueGame = ShouldGameContinue(blacksAndWhites);

            } while (continueGame);
            
            return _numberOfGuesses;
        }

        public bool ShouldGameContinue(string result)
        {
            if (result == "BBBB,")
                return false;
            else
                return true;
        }
    }
    public enum GuessStage
    {
        Black,
        White,
        Wrong
    }
}

   