using System;
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
        private string _targetToGuess;
        public MasterMind(IUI ui)
        {
            _ui = ui;
        }

        public string CheckGuess(string playerGuess)
        {
            _numberOfGuesses++;
            int white = 0, black = 0;
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
                    black++;
                }
                else
                {
                    white++;
                }
            }
            return "BBBB".Substring(0, black) + "," + "WWWW".Substring(0, white);
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
            bool continueGame = true;
            _ui.Output("New game:");
            CreateTargetToGuess();
            Console.WriteLine("For practice, number is: " + _targetToGuess); // DENNA SKA BORT INNAINLÄMNING

            while (continueGame)
            {
                string playerGuess = _ui.Input().Trim();
                string result = CheckGuess(playerGuess);
                _ui.Output(result);
                continueGame = ShouldGameContinue(result);
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
