﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Data
{
    public interface IDataHandler
    {
        public List<Player> GetScores(string chosenGame);
        public void PostScore(string Name, int numberOfGuesses, string chosenGame);

    }
}
