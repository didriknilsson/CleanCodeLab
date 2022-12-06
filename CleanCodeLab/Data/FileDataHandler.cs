using CleanCodeLab.Data;
using CleanCodeLab.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class FileDataHandler : IDataHandler
    {
        private string _filePath;
        public FileDataHandler(string filePath) // varför vill vi ha filePath här? För att vi använder det på flera ställen i projektet?
        {
            _filePath = filePath;
        }
        public List<PlayerData> GetScores(string chosenGame)
        {
            _filePath = ScoreFileFactory.GetFilePath(chosenGame);
            StreamReader scores = new StreamReader(_filePath);

            return ConvertToPlayerData(scores);

        }

        public void PostScore(string name, int numberOfGuesses, string chosenGame)
        {
            _filePath = ScoreFileFactory.GetFilePath(chosenGame);
            StreamWriter output = new StreamWriter(_filePath, append: true);
            output.WriteLine(name + "#&#" + numberOfGuesses);
            output.Close();
        }
        public List<PlayerData> ConvertToPlayerData(StreamReader scores)
        {
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = scores.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }
            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            return results;
        }
    }
}
