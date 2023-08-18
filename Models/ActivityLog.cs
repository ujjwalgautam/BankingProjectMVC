using System.ComponentModel.DataAnnotations;

namespace BankingProjectMVC.Models
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }
        public string  Teller{ get; set; }
        public DateTime Date { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }
    }
}
