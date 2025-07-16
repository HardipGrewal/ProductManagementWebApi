using BLL;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace ProductManagementWebApplication
{
    [Route("api/[controller]")]
    public class ProductManagement
    {
        private static readonly BLL.ProductManagement productsMan = new();

        /// <summary>
        /// Get List of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<ActionResult<List<Products>>> GetProducts()
        {
            var listProducts = productsMan.GetProducts();

            return Task.FromResult<ActionResult<List<Products>>>(listProducts);
        }

        /// <summary>
        /// Post Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        /// <param name="priceId"></param>
        [HttpPost]
        public void PostProducts(int productId, string name, int priceId)
        {
            if (productsMan.InsertProducts(productId, name, priceId) == true) { 
                // Give response
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        [HttpDelete]
        public void DeleteProducts(int productId)
        {
            if (productsMan.DeleteProducts(productId) == true)
            {
                // Give response
            }

        }

        /// <summary>
        /// Update Product name
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="name"></param>
        [HttpPatch]
        public void PatchProduct(int productId, string name)
        {
            if (productsMan.UpdateProductName(productId, name) == true)
            {
                // Give response
            }

        }
    }
}
