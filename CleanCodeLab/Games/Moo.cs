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
        private string _targetToGuess = "";
        public Moo(IUI ui)
        {
            _ui = ui;
        }

        public string CheckGuess(string playerGuess)
        {
            _numberOfGuesses++;
            if (playerGuess.Length < 4)
                playerGuess += "    ";
            int cows = 0, bulls = 0;
            for (int targetPos = 0; targetPos < 4; targetPos++)
            {
                for (int guessPos = 0; guessPos < 4; guessPos++)
                {
                    if (_targetToGuess[targetPos] == playerGuess[guessPos])
                    {
                        if (targetPos == guessPos)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return new string ('B', bulls) + "," + new string('C', cows);
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
                targetToGuess = targetToGuess + randomDigit;
            }
            _targetToGuess = targetToGuess;
        }

        public int PlayGame()
        {
            _numberOfGuesses = 0;
            bool continueGame = true;
            _ui.Output("New game:");
            CreateTargetToGuess();
            Console.WriteLine("For practice, number is: " + _targetToGuess); // DENNA SKA BORT INNAINLÄMNING

            while (continueGame)
            {
                string playerGuess = _ui.Input().Trim();
                string bullsAndCows = CheckGuess(playerGuess);
                _ui.Output(bullsAndCows);
                continueGame = ShouldGameContinue(bullsAndCows);
            }
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
}
