namespace ProductManagementTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private BLL.ProductManagement _bll = new BLL.ProductManagement();

        [Test]
        public void SelectProductTest1()
        {
            var products = _bll.GetProducts();

            if (products == null)
            {
                Assert.Fail();
            }
            else if (products.Count == 0) { Assert.Fail(); }
            else
            {
                Assert.Pass();
            }
        }
    }
}
