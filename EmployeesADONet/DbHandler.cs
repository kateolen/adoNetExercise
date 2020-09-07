using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeesADONet
{
    class DbHandler
    {
        private string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Employee> GetEmployees()

        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetEmployees", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee emp = new Employee();
                            emp.DepartmentName = reader["DepartmentName"].ToString();
                            emp.Name = reader["Name"].ToString();
                            emp.Job = reader["Job"].ToString();
                            emp.Location = reader["Location"].ToString();
                            emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                            employees.Add(emp);
                        }
                    }

                }
            }

            return employees;
        }

    }
}
