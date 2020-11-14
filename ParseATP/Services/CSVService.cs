using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

using CsvHelper;

using ParseATP.Util;
using ParseATP.Models;

namespace ParseATP.Services
{
	public class CSVService
	{
		public void CreateCSV(List<PlayerModel> players)
		{
			using (StreamWriter streamWriter = new StreamWriter(Constants.pathToCSV))
			{
				using (CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
				{
					csvWriter.Configuration.Delimiter = ";";
					csvWriter.WriteRecords(players);
				}
			}
		}
	}
}
