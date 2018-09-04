using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;

namespace FunnyBot
{
    public class HtmlParsing
    {
        static string HtmlText = string.Empty;
        public static string  GetHtmlPage(string url)
        {
            try
            {
                HttpWebRequest myHttWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttWebRequest.GetResponse();
                StreamReader strm = new StreamReader(myHttpWebResponse.GetResponseStream());
                HtmlText = strm.ReadToEnd();
                return HtmlText;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return String.Empty;
            }
        }
        public static string GetJoke(string HtmlText)
        {
            string result = string.Empty;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(HtmlText);
            HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//[@class='text']");
            if (coll != null) {
                foreach(var v in coll)
                {
                    Console.WriteLine("~~~ " + v);
                }
            }


            
            //string patternJoke;
            return result;
        }
    }
}
