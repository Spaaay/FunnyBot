using System;

namespace RovexBot
{
    class BotLogic : Bot
    {
        public static void DoSomething()
        {
        if (Message.Equals("/evgen") || Message.Equals("/evgen@roovexbot")) Commands.Evgen();
        else if (Message.Equals("/pic") || Message.Equals("/pic@roovexbot")) Commands.Pic();
        else if (Message.Equals("/founddog") || Message.Equals("/founddog@roovexbot"))  Commands.FoundDog(Users[ChatId]);
        else if (Message.Equals("/dogstats") || Message.Equals("/dogstats@roovexbot"))  Commands.DogsStatsForToday();
        else if (Message.StartsWith("/adddikyxa")) Commands.AddDikyxa();
        else if (Message.StartsWith("/adddoeb")) Commands.AddDoeb();
        else if (Message.StartsWith("/agr")) Commands.Agr();
        else if (Random.Next(1, Agressor) == 2) Commands.RandomDoeb(UserId.Username );
        }
    }
}
