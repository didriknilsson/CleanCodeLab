using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class PlayerData
    {
        public string Name { get; set; }
        public int TotalGuesses { get; set; }
        public int NumberOfGamesPlayed { get; set; }
        public double AverageScore { get; set; }
        public PlayerData(string name, int guesses)
        {
            Name = name;
            NumberOfGamesPlayed = 1;
            TotalGuesses = guesses;
        }

        public void UpdatePlayerData(int guesses)
        {
            TotalGuesses += guesses;
            NumberOfGamesPlayed++;
        }

        public void CalculateAverageScore()
        {
            AverageScore = (double)TotalGuesses / NumberOfGamesPlayed;
        }

        public override bool Equals(Object? player)
        {
            return Name.Equals(((PlayerData)player!).Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
