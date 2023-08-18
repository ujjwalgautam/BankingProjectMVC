using System.ComponentModel.DataAnnotations;

namespace BankingProjectMVC.Models
{
    public class BankDeposit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TotalAmount { get; set; }
        public int Thousands { get; set; }
        public int Hundreds { get; set; }
        public int FiveHUndreds { get; set; }
        public int  Fifities { get; set; }
        public int Twenties { get; set; }
        public int Tens { get; set; }
        public int Fives { get; set; } 
        public int Twos { get; set; }
        public int Ones { get; set; }
    }
}
