using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProjectMVC.Models
{
    public class Employee
    {
        [Key]
        public int UserId { get; set; }
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
