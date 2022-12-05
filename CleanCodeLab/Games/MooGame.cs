using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class MooGame : IGame
    {
        private IUI _ui;
        private int _numberOfGuesses { get; set; }
        private string _targetToGuess { get; set; }
        public MooGame(IUI ui)
        {
            _ui = ui;
        }

        public string CheckGuess(string playerGuess)
        {
            _numberOfGuesses++;
            int cows = 0, bulls = 0;
            if (playerGuess.Length < 4)
            {
                playerGuess += "    ";
            }
            char[] playerGuessCharArray = playerGuess.ToCharArray();
            char[] targetGuessCharArray = _targetToGuess.ToCharArray();
            foreach (var targetGuessChar in targetGuessCharArray.Where(targetGuessChar => playerGuessCharArray.Contains(targetGuessChar)))
            {
                if (Array.IndexOf(playerGuessCharArray, targetGuessChar) == Array.IndexOf(targetGuessCharArray, targetGuessChar))
                {
                    bulls++;
                }
                else
                {
                    cows++;
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
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
            bool continueGame = true;
            _ui.Output("New game:\n");
            while (continueGame)
            {
                CreateTargetToGuess();
                string playerGuess = _ui.Input();
                string result = CheckGuess(playerGuess);
                _ui.Output(result + "\n");
                continueGame = ShouldGameContinue(result);
            }
            return _numberOfGuesses;
        }

        public bool ShouldGameContinue(string result)
        {
            if (result == "BBBB")
                return false;
            else
                return true;
        }

    }
}
