using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingProjectMVC.Models
{
    public class Statement
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SN { get; set; }
        public string SenderAccountNumber { get; set; }
        public string SenderName { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string ReceiverName { get; set; }
        public decimal Amount { get; set; }
        public string Mode { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }

}

