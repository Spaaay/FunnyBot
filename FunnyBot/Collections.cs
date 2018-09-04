using System.Collections.Generic;
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
                List<string> list = new List<string>();
                list.Add(UserName);
                Users.Add(ChatId, new List<string>(list));
            }
            else if (!Users[ChatId].Contains(UserName))
            {
                Users[ChatId].Add(UserName);
            }
            // Text BD
            string temp = "";
            using (StreamReader fs = new StreamReader(@"..\..\AppData\BD_aggression.txt"))
            {
                while ((temp = fs.ReadLine()) != null)
                {
                    if (!AggressionList.Contains(temp)) AggressionList.Add(temp);
                }
            }
            using (StreamReader fs = new StreamReader(@"..\..\AppData\BD_random.txt"))
            {
                while ((temp = fs.ReadLine()) != null)
                {
                    if (!AggressionList.Contains(temp)) RandomList.Add(temp);
                }
            }
        }
    }
}
