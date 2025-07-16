using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class ProductsBase
    {
        private SqlConnection _connection = new SqlConnection();

        public ProductsBase()
        {
            
        }

        private string connstr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductManagement;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        /// <summary>
        /// Get All products
        /// </summary>
        public DataTable AllProducts()
        {
            SqlConnection connection = new();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[connstr].ConnectionString;
            DataTable dt = new DataTable();

            string queryString = """SELECT productId, name, priceId FROM dbo.Products;""";
            try
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                dt.Load(command.ExecuteReader());
                command.Connection.Close();
                return dt;
            }

            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Insert Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="priceId"></param>
        /// <returns></returns>
        public bool InsertProduct(int productId, string name, int priceId)
        {
            SqlConnection connection = new();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[connstr].ConnectionString;
            
            string queryString = $"""INSERT INTO [dbo].[Products] ([productId], [name], [priceId]) VALUES ({productId}, N'{name}', {priceId});""";
            try
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                command.ExecuteNonQuery();
                command.Connection.Close();
                return true;
            }

            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            SqlConnection connection = new();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[connstr].ConnectionString;

            string queryString = $"""Delete From [dbo].[Products] Where [productId] = {productId};""";
            try
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                command.ExecuteNonQuery();
                command.Connection.Close();
                return true;
            }

            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Update Product name
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateProductName(int productId, string name)
        {
            SqlConnection connection = new();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[connstr].ConnectionString;

            string queryString = $"""
                UPDATE [dbo].[Products] 
                set [name] = N'{name}'
                WHERE ProductId = {productId};
                """;
            try
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();

                command.ExecuteNonQuery();
                command.Connection.Close();
                return true;
            }

            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Get All Prices
        /// </summary>
        public void AllPrice()
        {
            SqlConnection connection = new();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings[connstr].ConnectionString;


            string queryString = """SELECT priceId, buyUnitPrice, sellUnitPrice FROM dbo.Prices;""";
            try
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                    }
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}