using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCApp1.Models
{


    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int DeptNo { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}, Deptno: {DeptNo}";
        }

        public static void Insert(Employee employee)
        {

            // Connection string for the database
            string connectionString = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False;";


            // SQL query to insert data
            string query = "INSERT INTO dbo.Employee (Id, Name, Salary, DeptNo) VALUES (@Id, @Name, @Salary, @DeptNo)";

            // Using a `using` block to ensure proper resource management
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    cn.Open();

                    // Create a SQL command with parameters to prevent SQL injection
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        // Add values to the parameters
                        cmd.Parameters.AddWithValue("@Id", employee.Id);
                        cmd.Parameters.AddWithValue("@Name", employee.Name);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);

                        // Execute the command
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception e)
                {
                    // Handle and log any errors
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public static List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            SqlDataReader dr;

            // Connection string for the database
            string connectionString = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False;";


            // SQL query to insert data
            string query = "SELECT * FROM dbo.Employee;";

            // Using a `using` block to ensure proper resource management
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    cn.Open();

                    // Create a SQL command with parameters to prevent SQL injection
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Employee obj = new Employee();
                            obj.Id = Convert.ToInt32(dr["Id"]);
                            obj.Name = (string)dr["Name"];
                            obj.Salary = (decimal)dr["Salary"];
                            obj.DeptNo = Convert.ToInt32(dr["DeptNo"]); ;
                            list.Add(obj);
                        }
                    }
                }
                catch (Exception e)
                {
                    // Handle and log any errors
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return list;
        }

        public static Employee Get(int id)
        {
            Employee obj = null;
            SqlDataReader dr = null;

            // Connection string for the database
            string connectionString = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False;";


            // SQL query to insert data
            string query = "SELECT * FROM dbo.Employee;";

            // Using a `using` block to ensure proper resource management
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    cn.Open();

                    // Create a SQL command with parameters to prevent SQL injection

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Employee WHERE Id=@id";
                    cmd.Parameters.AddWithValue("id", id);

                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        obj = new Employee();
                        obj.Id = Convert.ToInt32(dr["Id"]);
                        obj.Name = (string)dr["Name"];
                        obj.Salary = (decimal)dr["Salary"];
                        obj.DeptNo = Convert.ToInt32(dr["DeptNo"]); ;

                    }

                }
                catch (Exception e)
                {
                    // Handle and log any errors
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            return obj;
        }

        public static void Update(int id, Employee employee)
        {

            // Connection string for the database
            string connectionString = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False;";


            // Using a `using` block to ensure proper resource management
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    cn.Open();

                    // Create a SQL command with parameters to prevent SQL injection
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE dbo.Employee SET Name=@Name, Salary=@Salary, DeptNo=@DeptNo WHERE Id=@Id";
                    // Add values to the parameters
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    // Handle and log any errors
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

        public static void Delete(int id)
        {

            // Connection string for the database
            string connectionString = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False;";


            // Using a `using` block to ensure proper resource management
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection
                    cn.Open();

                    // Create a SQL command with parameters to prevent SQL injection
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM dbo.Employee WHERE Id=@Id";
                    // Add values to the parameters
                    cmd.Parameters.AddWithValue("@Id", id);

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    // Handle and log any errors
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
        }

    }

}
