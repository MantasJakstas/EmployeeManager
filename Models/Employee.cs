using System;
using System.Collections.Generic;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int Employeeid { get; set; }
        public string Employeename { get; set; } = null!;
        public int Employeesalary { get; set; }
    }
}
