using DAL;
using System.Data;

namespace BLL
{

    public class ProductManagement
    {


        public ProductManagement() { }

        private static readonly ProductsBase productsBase = new();
        private ProductsBase _dal = productsBase;
        /// <summary>
        /// Retrieve Products
        /// </summary>
        public List<Products> GetProducts()
        {
            DataTable dt = _dal.AllProducts();

            List<Products> productList = new List<Products>();
            productList = (from DataRow dr in dt.Rows
                           select new Products()
                           {
                               ProductId = Convert.ToInt32(dr["ProductId"]),
                               Name = dr["Name"].ToString(),
                               PriceId = Convert.ToInt32(dr["PriceId"])
                           }).ToList();
            return productList;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="priceId"></param>
        /// <returns></returns>
        public bool InsertProducts(int productId, string name, int priceId)
        {
            try
            {


                return _dal.InsertProduct(productId, name, priceId);
            }

            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProducts(int productId)
        {
            try
            {


                return _dal.DeleteProduct(productId);
            }

            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool UpdateProductName(int productId, string name)
        {
            try
            {


                return _dal.UpdateProductName(productId, name);
            }

            catch (Exception)
            {
                throw;
            }
        }

    }

    public class Products
    {
        public int ProductId { get; set; }
        public required string? Name { get; set; }
        public int PriceId { get; set; }
    }
}

