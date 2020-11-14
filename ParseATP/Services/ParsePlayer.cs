using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

using ParseATP.Util;
using ParseATP.Models;

namespace ParseATP.Services
{
	/// <summary>
	/// Player parsing functionality
	/// </summary>
	public class ParsePlayer
	{
		private string html;

		public ParsePlayer(string _html)
		{
			html = _html;
		}

		public PlayerModel GetPlayerAgeWeightHeight()
		{
			HtmlDocument doc = new HtmlDocument();
			doc.LoadHtml(html);

			IEnumerable<HtmlNode> nodes = doc.DocumentNode
				.SelectNodes("//div[@class='" + Constants.ageClassValue + "']");

			string name = GetName(doc);
			int age = GetAge(nodes.First());
			int weight = GetWeight(nodes.ToList()[2]);
			int height = GetHeight(nodes.ToList()[3]);

			PlayerModel player = new PlayerModel(name, age, weight, height);

			return player;
		}

		private string GetName(HtmlDocument doc)
		{
			HtmlNode title = doc.DocumentNode
				.SelectSingleNode("//title");

			return DeleteCharactersFromName(title.InnerText);
		}

		// Title looks like "Name | Overview | ..." so we need all the characters after the first "|" to be deleted
		private string DeleteCharactersFromName(string text)
		{
			return text.Substring(0, text.IndexOf('|')).Trim();
		}

		private int GetAge(HtmlNode divNode)
		{
			int.TryParse(divNode.Descendants()
				.First()
				.InnerText, 
				out int result);
			return result;
		}

		private int GetWeight(HtmlNode divNode)
		{
			string text = divNode.SelectSingleNode("span[@class='" + Constants.kgClassValue + "']")
				.InnerText;

			int result = ConvertStringToIntKg(text);

			return result;
		}

		private int GetHeight(HtmlNode divNode)
		{
			string text = divNode.SelectSingleNode("span[@class='" + Constants.cmClassValue + "']")
				.InnerText;

			int result = ConvertStringToIntCm(text);

			return result;
		}

		// Delete the characters from the string
		private int ConvertStringToIntKg(string text)
		{
			int.TryParse(text.Trim(new char[] { '(', ')', 'k', 'g' }), out int result);
			return result;
		}

		private int ConvertStringToIntCm(string text)
		{
			int.TryParse(text.Trim(new char[] { '(', ')', 'c', 'm' }), out int result);
			return result;
		}
	}
}
