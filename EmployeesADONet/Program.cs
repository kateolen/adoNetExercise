using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesADONet
{
    class Program
    {
        static void Main(string[] args)
        {
            DbHandler db = new DbHandler();
            List<Employee> empoyees = db.GetEmployees();
            db.GetEmployees();

            foreach (var item in empoyees)
            {
                Console.WriteLine($"{item.Name}  {item.DepartmentName} {item.Location}");
                
            }
            Console.ReadLine();
        }
    }
}
