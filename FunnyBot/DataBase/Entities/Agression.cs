using System.ComponentModel.DataAnnotations.Schema;

namespace FunnyBot.DataBase.Entities
{
    [Table("Aggression")]
    public class Agression
    {
        public int Id { get; set; }

        public string Phrase { get; set; }
    }
}
