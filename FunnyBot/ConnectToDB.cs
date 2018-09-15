using System.Data.Entity;
using System.Data.SQLite;

namespace FunnyBot
{
    public static class ConnectToDb
    {
        public static ApplicationContext db;
        public static void Connect()
        {
            //SQLite
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SQLiteConnection sqlite = new SQLiteConnection(connection);
            sqlite.Open();
            db = new ApplicationContext();
            db.RandomPhrases.Load();
            db.Agressions.Load();
            foreach (RandomPhrase random in db.RandomPhrases)
            {
                if (!Bot.AggressionList.Contains(random.Phrase))
                    Bot.RandomList.Add(random.Phrase);
            }
            foreach (Agression agrress in db.Agressions)
            {
                if (!Bot.AggressionList.Contains(agrress.Phrase))
                    Bot.AggressionList.Add(agrress.Phrase);
            }
        }
    }
}
