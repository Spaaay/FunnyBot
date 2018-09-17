using System.ComponentModel.DataAnnotations.Schema;

namespace FunnyBot.DataBase.Entities
{
    [Table("BestJoke")]
    public class BestJoke
    {
        public int Id { get; set; }

        public string Joke { get; set; }

        public string Raiting { get; set; }
    }
}
