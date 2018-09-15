using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;

namespace FunnyBot
{
    class Collections : Bot
    {
        public static void CreatingCollecrions()
        {
            // Adding Chat ID`s and Users
            if (!ChatIDs.Contains(ChatId)) ChatIDs.Add(ChatId);
            if (!Users.ContainsKey(ChatId))
            {
                var list = new List<string>();
                list.Add(UserName);
                Users.Add(ChatId, new List<string>(list));
            }
            else if (!Users[ChatId].Contains(UserName))
            {
                Users[ChatId].Add(UserName);
            }
        }  
    }
}
