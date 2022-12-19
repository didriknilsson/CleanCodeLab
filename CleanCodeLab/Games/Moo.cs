using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class Moo : IGame
    {
        public string Name { get; set; } = "Moo";
        private readonly IUI _ui;
        private int _numberOfGuesses;
        public string _targetToGuess = "";
        public Moo(IUI ui)
        {
            _ui = ui;
        }

        public string CheckGuess(string playerGuess)
        {
            _numberOfGuesses++;
            if (playerGuess.Length < 4)
                playerGuess += "    ";
            int almostCorrect = 0, correct = 0;
            for (int targetPos = 0; targetPos < 4; targetPos++)
            {
                for (int guessPos = 0; guessPos < 4; guessPos++)
                {
                    if (_targetToGuess[targetPos] == playerGuess[guessPos])
                    {
                        if (targetPos == guessPos)
                        {
                            correct++;
                        }
                        else
                        {
                            almostCorrect++;
                        }
                    }
                }
            }
            return new string ('B', correct) + "," + new string('C', almostCorrect);
        }

        public void CreateTargetToGuess()
        {
            Random randomGenerator = new Random();
            string targetToGuess = "";
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = randomGenerator.Next(10).ToString();
                while (targetToGuess.Contains(randomDigit))
                {
                    randomDigit = randomGenerator.Next(10).ToString();
                }
                targetToGuess += randomDigit;
            }
            _targetToGuess = targetToGuess;
        }

        public int PlayGame()
        {
            _numberOfGuesses = 0;
            bool continueGame;
            _ui.Output("New game:");
            CreateTargetToGuess();
            _ui.Output("Welcome to Moo! A 4 digit number between the numbers 1 to 9 has randomly been generated. Note that one digit can only appear one time. Your task will be to guess the correct number. Good luck!");
            _ui.Output("B will indicate right guess, C will indicate right guess wrong place.");

            do
            {
                string playerGuess = _ui.Input().Trim();
                string bullsAndCows = CheckGuess(playerGuess);
                _ui.Output(bullsAndCows);
                continueGame = ShouldGameContinue(playerGuess);
            } while (continueGame);
            return _numberOfGuesses;
        }

        public bool ShouldGameContinue(string playerGuess)
        {
            if (playerGuess == _targetToGuess)
                return false;
            else
                return true;
        }

    }
}
