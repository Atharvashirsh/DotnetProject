using Microsoft.Data.SqlClient;
using System.Data;

namespace ModelBinding.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();
                //dr.HasRows

                while (dr.Read())
                {
                    Employee obj = new Employee();
                    //obj.Name = dr[1].ToString();
                    //obj.Name = dr.GetString(1); ;
                    //obj.Name = dr["Name"].ToString();
                    //obj.Name = dr.GetString("Name"); ;

                    //obj.Name = dr["Name"].ToString();
                    //obj.EmpNo = (int)dr["EmpNo"];
                    //obj.Basic= (Decimal)dr["Basic"];
                    //obj.DeptNo = (int)dr["DeptNo"];

                    obj.Name = dr.GetString("Name"); ;
                    obj.EmpNo = dr.GetInt32("EmpNo");
                    obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");
                    employees.Add(obj);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return employees;
        }
        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee obj = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj = new Employee();
                    obj.Name = dr.GetString("Name"); ;
                    obj.EmpNo = dr.GetInt32("EmpNo");
                    obj.Basic = dr.GetDecimal("Basic");
                    obj.DeptNo = dr.GetInt32("DeptNo");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }

        public static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void Update(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employees set Name=@Name,Basic=@Basic,DeptNo=@DeptNo where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmd.Parameters.AddWithValue("@EmpNo", obj.EmpNo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void Delete(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";
            try
            {
                cn.Open();

                // SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Employees where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }


    }
}
