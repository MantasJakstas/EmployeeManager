using EmployeeManager.Data;
using EmployeeManager.EmployeeParse;
using EmployeeManager.Interface;
using EmployeeManager.Models;


namespace EmployeeManager.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Employee? GetEmployee(int employeeId, out Employee? employee)
        {
            using (_context)
            {
                try
                {
                    employee = _context.Employees.Find(employeeId);
                    return employee;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return employee = null;
                }
            }
        }

        public void SetEmployee(EmployeeAddOptions employee)
        {
            using (_context)
            {
                Employee employeeModel = new Employee()
                {
                    Employeeid = employee.EmployeeId,
                    Employeename = employee.EmployeeName,
                    Employeesalary = employee.EmployeeSalary,
                };
                try
                {
                    _context.Employees.Add(employeeModel);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
