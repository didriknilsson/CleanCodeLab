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
        public PlayerData(string name, int guesses)
        {
            Name = name;
            NumberOfGamesPlayed = 1;
            TotalGuesses = guesses;
        }

        public void Update(int guesses)
        {
            TotalGuesses += guesses;
            NumberOfGamesPlayed++;
        }

        public double Average()
        {
            return (double)TotalGuesses / NumberOfGamesPlayed;
        }

        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }


}
