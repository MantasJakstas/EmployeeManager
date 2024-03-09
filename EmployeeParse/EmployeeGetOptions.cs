using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.EmployeeParse
{
    internal class EmployeeGetOptions
    {
        [Option("employeeId", Required = true, HelpText = "EmployeeManager Id")]
        public int EmployeeId { get; set; }
    }
}
