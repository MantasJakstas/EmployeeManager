using EmployeeManager.EmployeeParse;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Interface
{
    internal interface IEmployeeService
    {
        void SetEmployee(EmployeeAddOptions employee);
        Employee? GetEmployee(int employeeId);
    }
}
