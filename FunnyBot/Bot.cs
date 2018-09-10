using System;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;


namespace FunnyBot
{
    class Bot
    {
        public static Random Random = new Random();
        public static TelegramBotClient BotClient;
        public static List<long> ChatIDs = new List<long>();
        public static Dictionary<long, List<string>> Users = new Dictionary<long, List<string>>();
        public static long ChatId;
        public static string Message;
        public static User UserId;
        public static string UserName;
        public static List<string> AggressionList = new List<string>();
        public static List<string> RandomList = new List<string>();
        public static bool Welcome;
        public static int Agressor = 8;

        static void Main(string[] args)
        {
            BotClient = new TelegramBotClient("581243302:AAFSsqS_ylNPB7-XNOmJ05Vtpih_kZbqljM");
            BotClient.OnMessage += HandleMessage;
            BotClient.StartReceiving();
            var tr = new Thread(Randomizator);
            tr.Start();
            Console.ReadLine();
        }
      
        static void HandleMessage(object sender, MessageEventArgs messageEventArgs)
        {
            try
            {
                // Variables
                ChatId = messageEventArgs.Message.Chat.Id;
                if (messageEventArgs.Message.Text != null) Message = messageEventArgs.Message.Text.ToLower();
                else Message = "";
                UserId = messageEventArgs.Message.From;
                UserName = UserId.FirstName + " " + UserId.LastName;
                // Welcome
                if (!Welcome) { BotSender.SendMessage(ChatId, "Добрейший вечерочек"); Welcome = true; }
                // Filling collections
                Collections.CreatingCollecrions();
                // Logic
                BotCommnands.DoSomething();
                // Debug
                Console.WriteLine(ChatId);
            }
            catch (Exception e)
            {
                Console.WriteLine("!!! " + e.Message);
                Console.WriteLine("=== " + e.Source);
            }
        }

        static void Randomizator()
        {
            while (true)
            {
                if (ChatIDs.Count != 0)
                {
                    var randomChat = ChatIDs[Random.Next(0, ChatIDs.Count)];
                    if (Random.Next(1, 200) == 74) BotLogic.RandomAction(randomChat);
                    Thread.Sleep(10000);
                }
            }
        }
    }
}
