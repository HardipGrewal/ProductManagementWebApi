namespace ProductManagementTestProject
{
    public class BLLProjectManagementTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private BLL.ProductManagement bll = new BLL.ProductManagement();

        [Test]
        public void SelectProductDataTest()
        {
            var products = bll.GetProducts();

            if (products == null)
            {
                Assert.Fail("Null returned");
            }
            else if (products.Count == 0) {
                Assert.Fail("Nothing returned");
            }
                Assert.Pass();
        }
    }
}
