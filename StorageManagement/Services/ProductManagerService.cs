using StorageManagement.Entities;
using StorageManagement.Entities.Enums;
using System.ComponentModel;
using System.Xml.Linq;
namespace StorageManagement.Services
{
    internal class ProductManagerService
    {
        private List<Products> _products = new List<Products>();

        public void AddProducts(int quantity)
        {
            UniteData();
            if (_products.Count == 0)
            {
                for (int i = 0; i < quantity; i++)
                {
                    Console.WriteLine("Product name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Product price");
                    double price = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("Product category");
                    Console.WriteLine("----ELETRONICS----TOOLS----COMPUTERS----PIECES----FOOD----TOYS----HYGIENIC----");
                    Category category = Enum.Parse<Category>(Console.ReadLine().ToUpper());
                    _products.Add(new Products(name, price, category, i));
                    Console.Clear();
                }
            }
            else
            {
                var prov = _products.Count + quantity;
                for (int i = _products.Count; i < prov; i++)
                {
                    Console.WriteLine("Product name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Product price");
                    double price = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                    Console.WriteLine("Product category");
                    Console.WriteLine("----ELETRONICS----TOOLS----COMPUTERS----PIECES----FOOD----TOYS----HYGIENIC----");
                    Category category = Enum.Parse<Category>(Console.ReadLine().ToUpper());
                    _products.Add(new Products(name, price, category, i));
                    Console.Clear();
                }
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

        public void AvgPrice()
        {
            if (_products.Count == 0)
                throw new ArgumentException("No added products in stock");

            double prov = _products.Average(p => p.Price);

            var prob2 = _products.Where(p => p.Price < prov);
            var prob = _products.Where(p => p.Price > prov);
            Console.WriteLine();
            Console.WriteLine("-----BELOW AVERAGE-----");
            foreach (Products product in prob2)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("-----ABOVE AVERAGE-----");
            foreach (Products product in prob)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
            Console.WriteLine("Avarage price of stock: " + prov.ToString("F2"), System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine();
        }
        public void SortList()
        {

            var prod = _products.OrderBy(p => p.Price).ThenBy(p => p.Name);
            foreach (Products product in prod)
            {
                Console.WriteLine(product);
            }
        }

        public void ModifyProduct(int id)
        {
            VerificationService service = new VerificationService();
            try
            {
                var modProduct = _products.Find(x => x.Id == id);
                if (modProduct == null)
                    throw new ArgumentNullException("This id doesnt exist");

                Console.WriteLine("---Product Data---");
                Console.WriteLine(modProduct);
                Console.WriteLine();
                Console.WriteLine("Modify name, price or category?(N/P/C)");
                char select = char.Parse(Console.ReadLine());
                if (select == 'n' || select == 'N')
                {
                    Console.Write("Write the new name:");
                    string name = Console.ReadLine();
                    modProduct.Name = name;
                }
                else if (select == 'p' || select == 'P')
                {
                    Console.Write("Write the new price:");
                    double price = double.Parse(Console.ReadLine());
                    modProduct.Price = price;
                }
                else
                {
                    Console.WriteLine("Write the new category:");
                    Category category = Enum.Parse<Category>(Console.ReadLine());
                    modProduct.Category = category;
                }
                _products[id] = modProduct;
                Console.WriteLine(_products[id]);
                service.ChangeData(modProduct);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("This id doesn't exist.");
            }
        }

        public void RemoveProduct(int id)
        {
            VerificationService service = new VerificationService();
            var modProduct = _products.Find(x => x.Id == id);
            if (modProduct == null)
                throw new ArgumentNullException("This id doesnt exist");

            Console.WriteLine("---Product Data---");
            Console.WriteLine(modProduct);
            _products.Remove(modProduct);
            service.RemoveData(id);
            Console.WriteLine("---Product Removed---");
        }
    }
}