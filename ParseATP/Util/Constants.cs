namespace ParseATP.Util
{
	public static class Constants
	{
		public const string playerClassValue = "player-cell"; // name of the class, where link to the player is located
		public const string ageClassValue = "table-big-value"; // name of the class, where age, height and weight are located
		public const string kgClassValue = "table-weight-kg-wrapper"; // name of the class, where value in kg is located
		public const string cmClassValue = "table-height-cm-wrapper"; // name of the class, where value in kg is located
		public const string siteUrl = "https://www.atptour.com";
		public const string mainUrl = siteUrl + "/en/rankings/singles";
		public const string defaultPlayerUrl = "https://www.atptour.com/en/players/roger-federer/f324/overview";
		public const string pathToCSV = @"D:\file.csv";
	}
}
