using StorageManagement.Entities.Enums;

namespace StorageManagement.Entities
{
    internal class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Products(string name, double price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public override string ToString()
        {
            return Name + "," + Price.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + "," + Category;
        }
    }
}
