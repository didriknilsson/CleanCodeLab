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
            if (playerGuess.Length < 4)
                playerGuess += "    ";
            _numberOfGuesses++;
            int correct = 0, almostCorrect = 0;
            char[] modifiedTargetToGuess = _targetToGuess.ToCharArray();

            for (int i = 0; i < 4; i++)
            {
                if (playerGuess[i] == _targetToGuess[i])
                {
                    correct++;
                    modifiedTargetToGuess[i] = '-';
                }
            }

            for (int i = 0; i < 4; i++)
            {
                if (modifiedTargetToGuess.Contains(playerGuess[i]))
                {
                    almostCorrect++;
                    modifiedTargetToGuess[Array.IndexOf(modifiedTargetToGuess, playerGuess[i])] = '-';
                }
            }
            return new string('R', correct) + "," + new string('W', almostCorrect);            
        }
        

        public void CreateTargetToGuess()
        {
            Random random = new Random();
            _targetToGuess = string.Join("", Enumerable.Range(1, 4).Select(digit => random.Next(1, 7)));          
        }

        public int PlayGame()
        {
            _numberOfGuesses = 0;
            bool continueGame;
            _ui.Output("New game:");
            CreateTargetToGuess();
            _ui.Output("Welcome to mastermind! A 4 digit number between the numbers 1 to 6 has randomly been generated. Note that the same digit can appear multiply times. Your task will be to guess the correct number. Good luck!");
            _ui.Output("R will indicate right guess, W will indicate right guess wrong place.");

            do
            {
                string playerGuess = _ui.Input().Trim();
                string redsAndWhites = CheckGuess(playerGuess);
                _ui.Output(redsAndWhites);
                continueGame = ShouldGameContinue(playerGuess);

            } while (continueGame);
            
            return _numberOfGuesses;
        }

        public bool ShouldGameContinue(string result)
        {
            if (result == _targetToGuess)
                return false;
            else
                return true;
        }
    }
}

   