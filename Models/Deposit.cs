using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProjectMVC.Models
{
    public class Depositt
    {
        [Key]
        public int Sno { get; set; }
        public DateTime Date { get; set; }
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public string Depositor { get; set; }
        [RegularExpression(@"^9\d{9}$", ErrorMessage = "Phone number should start with '9' and be exactly 10 digits.")]
        public string DepositorPhoneNo { get; set; }
        public int DipAmount { get; set; }
    }
}
