using System;
using System.Collections.Generic;
using ParseATP.Services;
using ParseATP.Util;
using ParseATP.Models;

namespace ParseATP
{
	class Program
	{
		static void Main(string[] args)
		{
			ParseMain parseMain = new ParseMain();
			string html = parseMain.GetPage(Constants.mainUrl);

			List<PlayerModel> players = parseMain.GetPlayers(html);

			CSVService cSVService = new CSVService();
			cSVService.CreateCSV(players);

			Console.WriteLine("done, path to file: " + Constants.pathToCSV);
		}
	}
}
