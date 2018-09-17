using System.ComponentModel.DataAnnotations.Schema;

namespace FunnyBot.DataBase.Entities
{
    [Table("RandomPhrase")]
    public class RandomPhrase
    {
        public int Id { get; set; }

        public string Phrase { get; set; }
    }
}