using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectMVC.Models
{
    public class CashCount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Thousands { get; set; }
        public int Hundreds { get; set; }
        public int FiveHUndreds { get; set; }
        public int Fifities { get; set; }
        public int Twenties { get; set; }
        public int Tens { get; set; }
        public int Fives { get; set; }
        public int Twos { get; set; }
        public int Ones { get; set; }
    }
}
