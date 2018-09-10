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
        private static string htmlText = "";
        public static string GetHtmlPage(string url)
        {
            //Encoding enc = Encoding.GetEncoding(1251);
            try
            {
                HttpWebRequest myHttWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttWebRequest.GetResponse();
                StreamReader strm = new StreamReader(myHttpWebResponse.GetResponseStream());
                htmlText = strm.ReadToEnd();
                strm.Close();
                return htmlText;
            }
            catch (Exception e)
            {
                Console.WriteLine("!" + e.Message);
                return String.Empty;
            }
        }

        public static string GetJoke(string htmlText)
        {
            string temp = "";
            string result = "";
            List<string> jokeList = new List<string>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);
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
        public static string GetPic(string htmlText)
        {
            string temp = "";
            string result = "";
            List<string> picList = new List<string>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);
            HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//*/div[contains(@class, 'post')]/img[contains(@class, 'hidden-phone')]");
            if (coll != null)
            {
                foreach (HtmlNode v in coll)
                {
                    temp = v.Attributes["src"].Value;
                    if (temp != "" && temp != null && !picList.Contains(temp)) picList.Add(temp);
                }
            }
            else Console.WriteLine("EMPTY");
            result = picList[Bot.Random.Next(0, picList.Count)];
            return result;
        }
    }
}
