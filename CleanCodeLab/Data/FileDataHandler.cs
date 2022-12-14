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
            StreamReader scoresStreamReader = new StreamReader(_filePath);

            List<string> scores = GetScoreList(scoresStreamReader);
            List<PlayerData> scoreBoard = ConvertToScoreBoard(scores);


            return scoreBoard; // dålig namn givning, den läser och konverterar. Ska man dela upp så att man har en läs, och en konvertera?
        }

        private List<PlayerData> ConvertToScoreBoard(List<string> scoreList)
        {
            List<PlayerData> scoreBoard = new List<PlayerData>();
            foreach (var score in scoreList)
            {
                PlayerData playerData = ParseScore(score);
                int pos = scoreBoard.IndexOf(playerData);
                if (pos < 0)
                {
                    scoreBoard.Add(playerData);
                }
                else
                {
                    scoreBoard[pos].Update(playerData.TotalGuesses);
                }
            }
            scoreBoard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            return scoreBoard;
        }

        public static PlayerData ParseScore(string score)
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
                //skriv ett test för detta start. så att man kan testa med test indata tex på en fil som inte finns. Bryta ut så att man kan göra delarna testbara.
                string name;
                int guesses;
                NewMethod(line, out name, out guesses);
                // slut
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

        private static void NewMethod(string line, out string name, out int guesses)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            name = nameAndScore[0];
            guesses = Convert.ToInt32(nameAndScore[1]);
        }
    }
}
