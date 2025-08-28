using StorageManagement.Entities;
using StorageManagement.Entities.Enums;
namespace StorageManagement.Services
{
    internal class ProductManagerService
    {
        private List<Products> _products = new List<Products>();

        public void AddProducts(int quantity)
        {
            for(int i = 0; i < quantity; i++)
            {
                Console.WriteLine("Product name:");
                string name = Console.ReadLine();
                Console.WriteLine("Product price");
                double price = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine("Product category");
                Console.WriteLine("----ELETRONICS----TOOLS----COMPUTERS----PIECES----FOOD----TOYS----HYGIENIC----");
                Category category = Enum.Parse<Category>(Console.ReadLine());
                _products.Add(new Products(name, price, category));
                Console.Clear();
            }
            UniteData();
        }

        public List<Products> returnList()
        {
            return _products;
        }

        public void UniteData()
        {
            if (VerificationService.VerificateData() == true)
            {
               _products = _products.Union(VerificationService.GetData()).ToList();
            }
        }
    }
}