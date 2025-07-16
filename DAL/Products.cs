
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class Products : ProductsBase
    {
        private SqlConnection _connection = new SqlConnection();

        public Products(SqlConnection connection)
        {
        }
    }
}
