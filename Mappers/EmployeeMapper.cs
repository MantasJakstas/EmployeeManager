using EmployeeManager.EmployeeParse;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee ToEmployee(this EmployeeAddOptions employeeAddOptions)
        {
            return new Employee
            {
                Employeeid = employeeAddOptions.EmployeeId,
                Employeename = employeeAddOptions.EmployeeName,
                Employeesalary = employeeAddOptions.EmployeeSalary
            };
        }
    }
}
