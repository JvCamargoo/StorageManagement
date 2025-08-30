using StorageManagement.Entities.Enums;

namespace StorageManagement.Entities
{
    internal class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int Id { get; set; }
        public Products(string name, double price, Category category, int id)
        {
            Name = name;
            Price = price;
            Category = category;
            Id = id;
        }
        public override string ToString()
        {
            return Name + "," + Price.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + "," + Category + "," + Id;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Products))
                throw new ArgumentException("That isn't a product");
            Products pod = obj as Products;
            return Id.Equals(pod.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
