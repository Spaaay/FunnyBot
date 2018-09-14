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
    

    public class Agression 
    {
        private string _phrase;
        public int Id { get; set; }

        public string Phrase
        {
            get { return _phrase; }
            set { _phrase = value;}
        }
    }

    public class RandomPhrase
    {
        private string _phrase;
        public int Id { get; set; }

        public string Phrase
        {
            get { return _phrase; }
            set { _phrase = value; }
        }
    }

    public class BestJoke 
    {
        private string _joke;
        private string _raiting;
        public int Id { get; set; }

        public string Joke
        {
            get { return _joke; }
            set { _joke = value; }
        }

        public string Raiting
        {
            get { return _raiting; }
            set { _raiting = value; }
        }
    }

}
