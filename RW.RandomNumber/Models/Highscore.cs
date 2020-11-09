using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RW.RandomNumber.Models
{
    [Table("tb_Highscore")]
    public class Highscore
    {
        public int Id { get; set; }
        [Required]
        public int DifficultyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RemainingGuesses { get; set; }
    }
}