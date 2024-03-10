using EmployeeManager.Data;
using EmployeeManager.EmployeeParse;
using EmployeeManager.Interface;
using EmployeeManager.Mappers;
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

        public Employee? GetEmployee(int employeeId)
        {
            try
            {
                var employee = _context.Employees.Find(employeeId);
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public void SetEmployee(EmployeeAddOptions employee)
        {
            try
            {
                _context.Employees.Add(employee.ToEmployee());
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
