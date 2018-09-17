using System.Data.Entity;
using FunnyBot.DataBase.Entities;

namespace FunnyBot
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Agression> Agressions { get; set; }

        public DbSet<RandomPhrase> RandomPhrases { get; set; }

        public DbSet<BestJoke> BestJokes { get; set; }
    }
}
