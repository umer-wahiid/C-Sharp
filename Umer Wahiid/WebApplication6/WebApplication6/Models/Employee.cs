using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Employee Name")]
        public string EmpName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public string ContNum { get; set; }

        [Required]
        public int Salary { get; set; }
    }
}
