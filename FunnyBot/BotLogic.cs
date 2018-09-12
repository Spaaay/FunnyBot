using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FunnyBot.Properties;
using Telegram.Bot.Types;
using static FunnyBot.HtmlParsing;


namespace FunnyBot
{
    class BotLogic : Bot
    {
        public static Dictionary<string, long> DogsStats = new Dictionary<string, long>();

        public static void Pic()
        {
            var pic = GetPic(GetHtmlPage(Settings.Default.PicUrl));
            BotSender.SendPicture(ChatId, new FileToSend(pic));
        }
        
        public static void Joke()
        {
            var joke = GetJoke(GetHtmlPage(Settings.Default.JokeUrl));
            BotSender.SendMessage(ChatId, joke);
        }

        public static void Currency()
        {
            var currency = GetCurrency(GetHtmlPage(Settings.Default.CurrencyUrl));
            BotSender.SendMessage(ChatId, Resources.Currency + String.Format("{0:dd/MM/yyyy}", DateTime.Today) + " = " + currency + "грн");

        }

        public static void Agr()
        {
            var x = 0;
            if (Int32.TryParse(Message.Substring(5), out x))
            {
                if (x > 2 && x < 10)
                {
                    Agressor = x;
                    BotSender.SendMessage(ChatId, Resources.Agressor_value + Agressor);
                }
                else
                {
                   BotSender.SendMessage(ChatId, Resources.Agressor_correct);
                }
            }
            else BotSender.SendMessage(ChatId, Resources.Agressor_correct);
        }

        public static void AddAggresion()
        {
            if (UserId.Id == Settings.Default.AdminId)
            {
                using (var FileWritter = System.IO.File.AppendText(@"..\..\AppData\BD_aggression.txt"))
                {
                    var temp = Message?.Substring(9).Trim();
                    if (temp != null && temp.Length > 2)
                    {
                        try
                        {
                            FileWritter.WriteLine(temp);
                            BotSender.SendMessage(ChatId, Resources.AddToBase + temp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("AddAggresion Exception: " + e.Message);
                        }

                    }
                    else BotSender.SendMessage(ChatId, Resources.AddToBase_error);
                }
            }
            else BotSender.SendMessage(ChatId, Resources.Access_denied);
        }

        public static void AddRandom()
        {
            if (UserId.Id == Settings.Default.AdminId)
            {
                using (var FileWritter = System.IO.File.AppendText(@"..\..\AppData\BD_random.txt"))
                {
                    var temp = Message?.Substring(11).Trim();
                    if (temp != null && temp.Length > 2)
                    {
                        try
                        {
                            FileWritter.WriteLine(temp);
                            BotSender.SendMessage(ChatId, Resources.AddToBase + temp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("AddRandom Exception: " + e.Message);
                        }

                    }
                    else BotSender.SendMessage(ChatId, Resources.AddToBase_error);
                }
            }
            else BotSender.SendMessage(ChatId, Resources.Access_denied);
        }

        public static void RandomAction(long chatId)
        {
            BotSender.SendMessage(chatId, RandomList[Random.Next(0, RandomList.Count - 1)]); 
        }

        public static void FoundDog(List<string> users)
        {
            if (users.Count > 1)
            {
                var randomGysb = Random.Next(0, users.Count);
                BotSender.SendMessage(ChatId, Resources.DogOfTheDay + users[randomGysb]);
                if (!DogsStats.ContainsKey(users[randomGysb])) DogsStats.Add(users[randomGysb], 1);
                else DogsStats[users[randomGysb]]++;
            }
            else
            {
                BotSender.SendMessage(ChatId, Resources.DogOfTheDay_few_players);
            }
        }
        public static void DogsStatsForToday()
        {
            if (DogsStats.Count > 0)
            {
                var temp = DogsStats.Aggregate("", (current, s) => current + s.Key + " - " + s.Value + Resources.DogOfTheDay_stats + "\n");
                BotSender.SendMessage(ChatId, temp);
            }
            else
            {
                BotSender.SendMessage(ChatId, Resources.DogOfTheDay_no_found);
            }
        }

        public static void RandomAggression(string idUser)
        {
            BotSender.SendMessage(ChatId, "@" + idUser+ " " + AggressionList[Random.Next(0, AggressionList.Count-1)]);
        }
    }
}
