using CommandLine;
using EmployeeManager.Data;
using EmployeeManager.EmployeeParse;
using EmployeeManager.Interface;
using EmployeeManager.Models;
using EmployeeManager.Services;

namespace EmployeeManager
{
    internal class Program
    {
        private readonly IEmployeeService _employeeService;
        public Program(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("No arguments provided");
                return;
            }

            ApplicationDbContext context = new ApplicationDbContext();
            Program program = new Program(new EmployeeService(context));

            program.Run(args);
        }

        void Run(string[] args)
        {
            switch (args[0])
            {
                case "set-employee":
                    Parser.Default.ParseArguments<EmployeeAddOptions>(args).WithParsed(o => _employeeService.SetEmployee(o));
                    break;
                case "get-employee":
                    Employee? employee = null;
                    Parser.Default.ParseArguments<EmployeeGetOptions>(args).WithParsed(o => _employeeService.GetEmployee(o.EmployeeId, out employee));

                    if (employee == null)
                    {
                        Console.WriteLine("Employee not found");
                        break;
                    }

                    Console.WriteLine($"ID: {employee.Employeeid}, Name: {employee.Employeename}, Salary: {employee.Employeesalary}");
                    break;
                default:
                    Console.Error.WriteLine("No such method exists");
                    break;
            }
        }
    }
}
