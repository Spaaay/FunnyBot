using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot.Types;
using static FunnyBot.HtmlParsing;


namespace FunnyBot
{
    class BotLogic : Bot
    {
        public static Dictionary<string, long> DogsStats = new Dictionary<string, long>();
        public static BotSender BotSender = new BotSender();
        

        public static void Pic()
        {
            string url = "http://vse-shutochki.ru/kartinki-prikolnye";
            string pic = GetPic(GetHtmlPage(url));
            BotSender.SendPicture(ChatId, new FileToSend(pic));
        }

        public static void Joke()
        {
            string url = "https://www.anekdot.ru/random/anekdot/";
            string joke = GetJoke(GetHtmlPage(url));
            BotSender.SendMessage(ChatId, joke);
        }
        public static void Agr()
        {
            int x = 0;
            if (Int32.TryParse(Message.Substring(5), out x))
            {
                if (x > 2 && x < 10)
                {
                    Agressor = x;
                    BotSender.SendMessage(ChatId, "Значение агресивности - " + Agressor);
                }
                else
                {
                   BotSender.SendMessage(ChatId, "Введите корректное значение в диапазоне 3-10 (Пример: /agr 7)");
                }
            }
            else BotSender.SendMessage(ChatId, "Введите корректное значение в диапазоне 3-10 (Пример: /agr 7)");
        }

        public static void AddAggresion()
        {
            if (UserId.Id == 317300041)
            {
                using (var FileWritter = System.IO.File.AppendText(@"..\..\AppData\BD_aggression.txt"))
                {
                    var temp = Message?.Substring(9).Trim();
                    if (temp.Length > 2)
                    {
                        try
                        {
                            FileWritter.WriteLine(temp);
                            BotSender.SendMessage(ChatId, "Добавил в базу - " + temp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("+++++ " + e.Message);
                        }

                    }
                    else BotSender.SendMessage(ChatId, "Не добавлено, минимум 3 знака");
                }
            }
            else BotSender.SendMessage(ChatId, "Недостаточно прав");
        }

        public static void AddRandom()
        {
            if (UserId.Id == 317300041)
            {
                using (var FileWritter = System.IO.File.AppendText(@"..\..\AppData\BD_random.txt"))
                {
                    var temp = Message?.Substring(11).Trim();
                    if (temp.Length > 2)
                    {
                        try
                        {
                            FileWritter.WriteLine(temp);
                            BotSender.SendMessage(ChatId, "Добавил в базу - " + temp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("+++++ " + e.Message);
                        }

                    }
                    else BotSender.SendMessage(ChatId, "Не добавлено, минимум 3 знака");
                }
            }
            else BotSender.SendMessage(ChatId, "Недостаточно прав");
        }

        public static void RandomAction(long cId)
        {
            BotSender.SendMessage(cId, RandomList[Random.Next(0, RandomList.Count - 1)]); 
        }

        public static void FoundDog(List<string> users)
        {
            if (users.Count > 1)
            {
                var randomGysb = Random.Next(0, users.Count);
                BotSender.SendMessage(ChatId, "Пёс дня сегодня: " + users[randomGysb]);
                if (!DogsStats.ContainsKey(users[randomGysb])) DogsStats.Add(users[randomGysb], 1);
                else DogsStats[users[randomGysb]]++;
            }
            else
            {
                BotSender.SendMessage(ChatId, "Количество участников недостаточное для начала игры, напишите хоть что-то в чат ");
            }
        }
        public static void DogsStatsForToday()
        {
            if (DogsStats.Count > 0)
            {
                var temp = "";
                foreach (var s in DogsStats)
                {
                    temp = temp + s.Key + " - " + s.Value + " раз был псом сегодня" + "\n";
                }
                BotSender.SendMessage(ChatId, temp);
            }
            else
            {
                BotSender.SendMessage(ChatId, "Собаки пока не найдены");
            }
        }

        public static void RandomAggression(string IdUser)
        {

            BotSender.SendMessage(ChatId, "@" + IdUser+ " " + AggressionList[Random.Next(0, AggressionList.Count-1)]);
        }
    }
}
