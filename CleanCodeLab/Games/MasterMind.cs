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
            //Increase the number of guesses the player has made
            _numberOfGuesses++;
            // Keep track of the number of correct and almost correct digits
            int correct = 0;
            int almostCorrect = 0;

            // Make a copy of the secret code that we can modify
            char[] targetToGuessCopy = _targetToGuess.ToCharArray();

            // Check the guess
            for (int i = 0; i < playerGuess.Length; i++)
            {
                if (playerGuess[i] == _targetToGuess[i])
                {
                    // This digit is correct
                    correct++;
                    targetToGuessCopy[i] = '-';
                }
            }

            for (int i = 0; i < playerGuess.Length; i++)
            {
                if (targetToGuessCopy.Contains(playerGuess[i]))
                {
                    // This digit is almost correct
                    almostCorrect++;
                    targetToGuessCopy[Array.IndexOf(targetToGuessCopy, playerGuess[i])] = '-';
                }
            }
            string result = $"{correct} are correct, {almostCorrect} are almost correct only in the wrong order";
            return result;
            
        }

        

        public void CreateTargetToGuess()
        {
            // Generate a random code of 4 integers between 1 and 6 as a string
            Random random = new Random();
            _targetToGuess = string.Join("", Enumerable.Range(1, 4).Select(x => random.Next(1, 7)));
          
        }

        public int PlayGame()
        {
            _numberOfGuesses = 0;
            bool continueGame;
            _ui.Output("New game:");
            CreateTargetToGuess();
            _ui.Output("Welcome to mastermind\nA 4 digit number between the numbers 1 to 6 has randomly been generated. Note that the same digit can appear multiply times.\nYour task will be to guess the correct number\nGood luck!");
            Console.WriteLine("For practice, number is: " + _targetToGuess); // DENNA SKA BORT INNAINLÄMNING

            do
            {
                string playerGuess = _ui.Input().Trim();
                string blacksAndWhites = CheckGuess(playerGuess);
                _ui.Output(blacksAndWhites);
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
    public enum GuessStage
    {
        Black,
        White,
        Wrong
    }
}

   