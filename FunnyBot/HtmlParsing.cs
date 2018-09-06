using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;

namespace FunnyBot
{
    public class HtmlParsing
    {
        static string HtmlText = string.Empty;
        static public List<string> jokeList = new List<string>();

        public static string GetHtmlPage(string url)
        {
            //Encoding enc = Encoding.GetEncoding(1251);
            try
            {
                HttpWebRequest myHttWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttWebRequest.GetResponse();
                StreamReader strm = new StreamReader(myHttpWebResponse.GetResponseStream());
                HtmlText = strm.ReadToEnd();
                strm.Close();
                return HtmlText;
            }
            catch (Exception e)
            {
                Console.WriteLine("!" + e.Message);
                return String.Empty;
            }
        }

        public static string GetJoke(string HtmlText)
        {
            string temp = "";
            string result = string.Empty;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(HtmlText);
            //HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//html/body/div[2]/div[4]/div[2]/div/div[contains(@class, 'text')]/div");
            HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//*/div[contains(@class, 'text')]");
            if (coll != null)
            {
                foreach (HtmlNode v in coll)
                {
                    if (!v.InnerHtml.Contains("&#8230") && !v.InnerHtml.Contains("function") && !v.InnerHtml.Contains("&quot;") && !v.InnerHtml.Contains("<span>"))
                    {
                        temp = v.InnerHtml;
                        temp = temp.Replace("<br>", "\r\n");
                        if (temp != "" && temp != null && !jokeList.Contains(temp)) jokeList.Add(temp);
                    }
                }
            }
            else Console.WriteLine("EMPTY");
            result = jokeList[Bot.Random.Next(0, jokeList.Count)];
            return result;
        }
    }
}
