using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    [Keyless]
    public class formVM
    {
        public IEnumerable<Employee> EmpData { get; set; }
        public Employee Emp { get; set; }
    }
}
