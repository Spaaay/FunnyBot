using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace FunnyBot
{
    public class HtmlParsing
    {
        private static string _htmlText = string.Empty;
        private static List<JsonCurrency> _currencyList = new List<JsonCurrency>();

        public static string GetHtmlPage(string url)
        {
            //Encoding enc = Encoding.GetEncoding(1251);
            try
            {
                HttpWebRequest myHttWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttWebRequest.GetResponse();
                using (StreamReader strm = new StreamReader(myHttpWebResponse.GetResponseStream()))
                {
                    _htmlText = strm.ReadToEnd();
                }
                return _htmlText;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetHtmlPage Exception: " + e.Message);
                return string.Empty;
            }
        }

        public static string GetJoke(string page)
        {
            var temp = string.Empty;
            var result = string.Empty;
            var jokeList = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(page);
            HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//*/div[contains(@class, 'text')]");
            if (collection != null)
            {
                foreach (HtmlNode v in collection)
                {
                    if (!v.InnerHtml.Contains("&#8230") && !v.InnerHtml.Contains("function") &&
                        !v.InnerHtml.Contains("&quot;") && !v.InnerHtml.Contains("<span>"))
                    {
                        temp = v.InnerHtml;
                        temp = temp.Replace("<br>", "\r\n");
                        if (temp != "" && !jokeList.Contains(temp)) jokeList.Add(temp);
                    }
                }
            }
            else Console.WriteLine("GetJoke collection is empty ");
            result = jokeList[Bot.Random.Next(0, jokeList.Count)];
            return result;
        }

        public static string GetPic(string page)
        {
            var temp = string.Empty;
            var result = string.Empty;
            var picList = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(page);
            HtmlNodeCollection collection =
                doc.DocumentNode.SelectNodes("//*/div[contains(@class, 'post')]/img[contains(@class, 'hidden-phone')]");
            if (collection != null)
            {
                foreach (HtmlNode v in collection)
                {
                    temp = v.Attributes["src"].Value;
                    if (!string.IsNullOrEmpty(temp) && !picList.Contains(temp)) picList.Add(temp);
                }
            }
            else Console.WriteLine("GetPic  collection is empty");
            result = picList[Bot.Random.Next(0, picList.Count)];
            return result;
        }

        public static double GetCurrency(string jsonUrl)
        {
            _currencyList = JsonConvert.DeserializeObject<List<JsonCurrency>>(jsonUrl);
            foreach (var i in _currencyList)
            {
                if (i.cc.ToLower().Equals("usd")) return Math.Round(i.rate, 2);
            }
            return 0;
        }

        public class JsonCurrency
        {
            [JsonProperty("r030")]
            public int r030 { get; set; }
            [JsonProperty("txt")]
            public string txt { get; set; }
            [JsonProperty("rate")]
            public double rate { get; set; }
            [JsonProperty("cc")]
            public string cc { get; set; }
            [JsonProperty("exchangedate")]
            public string exchangedate { get; set; }
        }
    }
}
