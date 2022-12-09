using System;
using System.IO;
using System.Collections.Generic;
using CleanCodeLab.Factories;
using CleanCodeLab.Data;

namespace CleanCodeLab
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			IUI ui = new ConsoleIO();
			GameFactory factory = new GameFactory(ui);
			IGameDataHandler dataHandler = new FileDataHandler();
			var controller = new GamesController(ui, factory, dataHandler);
			controller.Run();		
		}		
	}   
}