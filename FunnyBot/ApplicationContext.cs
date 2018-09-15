using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

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

    [Table("Aggression")]
    public class Agression 
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
    }

    [Table("RandomPhrase")]
    public class RandomPhrase
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
    }

    [Table("BestJoke")]
    public class BestJoke 
    {
        public int Id { get; set; }
        public string Joke { get; set; }
        public string Raiting { get; set; }
    }

}
