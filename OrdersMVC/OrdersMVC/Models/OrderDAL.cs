using System.Data;
using Microsoft.Data.SqlClient;

namespace OrdersMVC.Models
{
    public static class OrderDAL
    {
        public static void AddOrder(OrderModel obj)
        {
            string connection = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False";

            SqlConnection cn = new SqlConnection(connection);

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO tbl_orders (CustomerName, ItemName, ItemPrice, ItemQty) VALUES (@cname, @iname, @iprice, @iqty);";

                cmd.Parameters.AddWithValue("cname", obj.CustomerName);
                cmd.Parameters.AddWithValue("iname", obj.ItemName);
                cmd.Parameters.AddWithValue("iprice", obj.ItemPrice);
                cmd.Parameters.AddWithValue("iqty", obj.ItemQty);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public static List<OrderModel> SearchOrder(string text)
        {
            List<OrderModel> list = new List<OrderModel>();
            string connection = @"Data Source=DESKTOP-65QUMT6;Initial Catalog=dotnet;Integrated Security=True;Encrypt=False";
            SqlConnection cn = new SqlConnection(connection);

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM tbl_orders WHERE OrderID LIKE '%' + @text +'%' OR CustomerName LIKE '%' + @text +'%';";

                cmd.Parameters.AddWithValue("@text", text);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OrderModel obj = new OrderModel();
                    obj.OrderID = (int)reader["OrderID"];
                    obj.CustomerName = (string)reader["CustomerName"];
                    obj.ItemName = (string)reader["ItemName"];
                    obj.ItemPrice = (decimal)reader["ItemPrice"];
                    obj.ItemQty = (int)reader["ItemQty"];
                    list.Add(obj);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return list;
        }
    }
}
