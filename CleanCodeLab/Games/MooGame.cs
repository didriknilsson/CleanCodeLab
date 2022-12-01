using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab
{
    public class MooGame : IGame
    {
        public string CreateTargetToGuess()
        {
			Random randomGenerator = new Random();
			string targetToGuess = "";
			for (int i = 0; i < 4; i++)
			{
				string randomDigit = randomGenerator.Next(10).ToString();
				while (targetToGuess.Contains(randomDigit))
				{
					randomDigit = randomGenerator.Next(10).ToString();
				}
				targetToGuess = targetToGuess + randomDigit;
			}
			return targetToGuess;
		}

        public string CheckPlayerGuess(string playerGuess, string targetToGuess)
        {
			int cows = 0, bulls = 0;
			if(playerGuess.Length < 4)
            {
				playerGuess += "    ";
            }
			char[] playerGuessCharArray = playerGuess.ToCharArray();
			char[] targetGuessCharArray = targetToGuess.ToCharArray();
			foreach (var targetGuessChar in targetGuessCharArray.Where(targetGuessChar => playerGuessCharArray.Contains(targetGuessChar)))
			{
				if (Array.IndexOf(playerGuessCharArray, targetGuessChar) == Array.IndexOf(targetGuessCharArray, targetGuessChar))
				{
					bulls++;
				}
				else
				{
					cows++;
				}
			}
			return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
			//foreach (var targetGuessChar in targetGuessCharArray)
			//{
			//	if (playerGuessCharArray.Contains(targetGuessChar))
			//	{

			//		if (Array.IndexOf(playerGuessCharArray, targetGuessChar) == Array.IndexOf(targetGuessCharArray, targetGuessChar))
			//		{
			//			bulls++;
			//		}
			//		else
			//		{
			//			cows++;
			//		}
			//	}

			//}
			//playerGuess += "    ";     // if player entered less than 4 chars
			//for (int i = 0; i < 4; i++)
			//{
			//	for (int j = 0; j < 4; j++)
			//	{
			//		if (targetToGuess[i] == playerGuess[j])
			//		{
			//			if (i == j)
			//			{
			//				bulls++;
			//			}
			//			else
			//			{
			//				cows++;
			//			}
			//		}
			//	}
			//}
			//return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		}
    }
}
