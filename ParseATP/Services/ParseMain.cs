using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;

using ParseATP.Util;
using ParseATP.Models;

namespace ParseATP.Services
{
	/// <summary>
	/// Main parsing functionality
	/// </summary>
	/// <param name="url">Page address</param>
	public class ParseMain
	{
        // Returns page code from url
        public string GetPage(string url)
        {
            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader streamReader;
                    if (response.CharacterSet != null)
                        streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                    else
                        streamReader = new StreamReader(responseStream);
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                response.Close();
            }
            return result;
        }

        public List<PlayerModel> GetPlayers(string html)
        {
            List<PlayerModel> players = new List<PlayerModel>();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            IEnumerable<HtmlNode> nodes = doc.DocumentNode
                .SelectNodes("//td[@class='" + Constants.playerClassValue + "']");

            foreach (HtmlNode node in nodes)
            {
                HtmlNode link = node.SelectSingleNode("a");

				string htmlPlayer = GetPage(Constants.siteUrl + link.GetAttributeValue("href", Constants.defaultPlayerUrl));

				ParsePlayer parsePlayer = new ParsePlayer(htmlPlayer);
				PlayerModel player = parsePlayer.GetPlayerAgeWeightHeight();
				players.Add(player);

				if (players.Count >= 10)
					break;
			}

            return players;
        }
    }
}
