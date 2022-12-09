using CleanCodeLab.Data;
using CleanCodeLab.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class FileDataHandler : IGameDataHandler
    {
        private string? _filePath;
        public FileDataHandler()
        {
            
        }
        public List<PlayerData> GetAllUserAverageScores(string chosenGame)
        {
            _filePath = $"{chosenGame}.txt";
            StreamReader scores = new StreamReader(_filePath);

            return ConvertToPlayerData(scores);
        }

        public void SavePlayersScore(string name, int numberOfGuesses, string chosenGame)
        {
            _filePath = $"{chosenGame}.txt";
            StreamWriter output = new StreamWriter(_filePath, append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }
        public List<PlayerData> ConvertToPlayerData(StreamReader scores)
        {
            List<PlayerData> scoreBoard = new List<PlayerData>();
            string line;
            while ((line = scores.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = scoreBoard.IndexOf(pd);
                if (pos < 0)
                {
                    scoreBoard.Add(pd);
                }
                else
                {
                    scoreBoard[pos].Update(guesses);
                }
            }
            scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            scores.Close();
            return scoreBoard;
        }
    }
}
