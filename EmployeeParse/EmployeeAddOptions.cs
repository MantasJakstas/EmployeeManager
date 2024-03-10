using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.EmployeeParse
{
    public class EmployeeAddOptions
    {
        [Option("employeeId", Required = true, HelpText = "EmployeeManager Id")]
        public int EmployeeId { get; set; }
        [Option("employeeName", Required = true, HelpText = "EmployeeManager Name")]
        public string EmployeeName { get; set; } = string.Empty;
        [Option("employeeSalary", Required = true, HelpText = "EmployeeManager Salary")]
        public int EmployeeSalary { get; set; }
    }
}
