using System;
using System.Collections.Generic;
using System.IO;
using Telegram.Bot.Types;


namespace RovexBot
{
    class Commands : Bot
    {
        public static Dictionary<string, long> DogsStats = new Dictionary<string, long>();
        public static BotSender BotSender = new BotSender();

        public static void Pic()
        {
            BotSender.SendPicture(ChatId, new FileToSend("https://goo.gl/qsRbXW"));
        }

        public static void Evgen()
        {
            BotSender.SendMessage(ChatId, "No no no ! EvgenDog");
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

        public static void AddDoeb()
        {
            if (UserId.Id == 317300041)
            {
                using (var FileWritter = System.IO.File.AppendText(@"..\..\AppData\BD_doeb.txt"))
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
            else BotSender.SendMessage(ChatId, "Ты кто такой пёс, иди гуляй, только владыка может добавлять фразы");
        }

        public static void AddDikyxa()
        {
            if (UserId.Id == 317300041)
            {
                using (var FileWritter = System.IO.File.AppendText(@"..\..\AppData\BD_dikyxa.txt"))
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
            else BotSender.SendMessage(ChatId, "Ты кто такой пёс, иди гуляй, только владыка может добавлять фразы");
        }

        public static void RandomDikyxa(long cId)
        {
            BotSender.SendMessage(cId, DikyxaList[Random.Next(0, DikyxaList.Count - 1)]); 
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
                BotSender.SendMessage(ChatId, "Количество гусей недостаточное для начала этой хуйни, напишите какую-то поеботу в чат ");
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
                BotSender.SendMessage(ChatId, "Собаки пока не найдены (кроме Жени)");
            }
        }

        public static void RandomDoeb(string iDpacana)
        {

            BotSender.SendMessage(ChatId, "@" + iDpacana+ " " + DoebList[Random.Next(0, DoebList.Count-1)]);
        }
    }
}
