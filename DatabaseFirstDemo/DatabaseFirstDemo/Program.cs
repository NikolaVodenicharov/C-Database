using DatabaseFirstDemo.Data;
using System;
using System.Linq;

namespace DatabaseFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using(var context = new SoftUniDbContext())
            {
                var employees = context.Employees.Select(e => new
                {
                    e.FirstName,
                    e.EmployeesProjects.Count

                }).ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FirstName + " " + employee.Count);
                }
            }

            Console.WriteLine("hi");
        }
    }
}
