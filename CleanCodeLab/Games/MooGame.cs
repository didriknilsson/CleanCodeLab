﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class MooGame : IGame
    {

        public string CheckGuess(string target, string guess)
        {
            throw new NotImplementedException();
        }

        public string CreateTargetToGuess()
        {
			Random randomGenerator = new Random();
			string goal = "";
			for (int i = 0; i < 4; i++)
			{
				int random = randomGenerator.Next(10);
				string randomDigit = "" + random;
				while (goal.Contains(randomDigit))
				{
					random = randomGenerator.Next(10);
					randomDigit = "" + random;
				}
				goal = goal + randomDigit;
			}
			return goal;
		}

        public bool ShouldGameContinue()
        {
            throw new NotImplementedException();
        }
    }
}
