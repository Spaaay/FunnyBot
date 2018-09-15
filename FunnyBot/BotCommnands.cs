using System;

namespace FunnyBot
{
    class BotCommnands : Bot
    {
        public static void DoSomething()
        {
        if (Message.Equals("/joke") || Message.Equals("/joke@funny_luckybot")) BotLogic.Joke();
        else if (Message.Equals("/pic") || Message.Equals("/pic@funny_luckybot")) BotLogic.Pic();
        else if (Message.Equals("/founddog") || Message.Equals("/founddog@funny_luckybot"))  BotLogic.FoundDog(Users[ChatId]);
        else if (Message.Equals("/dogstats") || Message.Equals("/dogstats@funny_luckybot"))  BotLogic.DogsStatsForToday();
        else if (Message.Equals("/currency") || Message.Equals("/currency@funny_luckybot")) BotLogic.Currency();
        else if (Message.StartsWith("/addrandom ")) BotLogic.AddRandom();
        else if (Message.StartsWith("/addaggresion ")) BotLogic.AddAggresion();
        else if (Message.StartsWith("/agr")) BotLogic.Agr();
        else if (Random.Next(1, Agressor) == 2) BotLogic.RandomAggression(UserId.Username );
        }
    }
}
