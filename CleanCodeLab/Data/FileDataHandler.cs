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
        public FileDataHandler()
        {
            
        }
        public List<PlayerData> GetLeaderBoard(string chosenGame)
        {
            StreamReader scoresStreamReader;
            string filePath = $"{chosenGame}.txt";
            try
            {
                scoresStreamReader = new StreamReader(filePath);
            }
            catch
            {
                return new List<PlayerData>();
            }

            List<string> scores = GetScoreList(scoresStreamReader);
            List<PlayerData> leaderBoard = ConvertToLeaderBoard(scores);

            return leaderBoard; 
        }

        private List<PlayerData> ConvertToLeaderBoard(List<string> scoreList)
        {
            List<PlayerData> leaderBoard = new List<PlayerData>();
            foreach (var score in scoreList)
            {
                PlayerData playerData = ParsePlayerAndScore(score);
                int pos = leaderBoard.IndexOf(playerData);
                if (pos < 0)
                {
                    leaderBoard.Add(playerData);
                }
                else
                {
                    leaderBoard[pos].Update(playerData.TotalGuesses);
                }
            }

            leaderBoard = CalculateLeaderBoard(leaderBoard);
            return leaderBoard;
        }

        private List<PlayerData> CalculateLeaderBoard(List<PlayerData> leaderBoard)
        {
            leaderBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            return leaderBoard;
        }

        public PlayerData ParsePlayerAndScore(string score)
        {
            string[] nameAndScore = score.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            return new PlayerData(name, guesses);
        }

        private List<string> GetScoreList(StreamReader scoresStreamReader)
        {
            List<string> scoreData = new List<string>();
            
            while(scoresStreamReader.ReadLine() is { } line)
            {
                scoreData.Add(line);
            }
            scoresStreamReader.Close();
            return scoreData;
        }

        public void SavePlayersScore(string name, int numberOfGuesses, string chosenGame)
        {
            string filePath = $"{chosenGame}.txt";
            StreamWriter output = new StreamWriter(filePath, append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }
    }
}
