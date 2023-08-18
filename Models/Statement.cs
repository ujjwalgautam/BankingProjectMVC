using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectMVC.Models
{
    public class Statement
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SN { get; set; }
        public string Description { get; set; }
        public decimal WithdrawAmount { get; set; }
        public decimal DepositAmount { get; set; }
        public string Mode { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }

}

