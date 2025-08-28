using StorageManagement.Entities;
using StorageManagement.Entities.Enums;
using System.IO;
namespace StorageManagement.Services
{
    internal class VerificationService
    {
        public static bool VerificateData()
        {
            string path = "C:\\Users\\joaov\\source\\repos\\StorageManagement\\StorageManagement\\Data\\data.txt";
            FileInfo data = new FileInfo(path);
            if (data.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void WriteInData(List<Products> list)
        {
            string path = "C:\\Users\\joaov\\source\\repos\\StorageManagement\\StorageManagement\\Data\\data.txt";
            Console.WriteLine("ESCREVENDO DADOS");
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (Products obj in list)
                {
                    sw.WriteLine(obj);
                }
            }
        }
        public static List<Products> GetData()
        {
            string path = "C:\\Users\\joaov\\source\\repos\\StorageManagement\\StorageManagement\\Data\\data.txt";
            List<Products> products1 = new List<Products>();
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(",");
                    string name = fields[0];
                    double price = double.Parse(fields[1], System.Globalization.CultureInfo.InvariantCulture);
                    Category category = Enum.Parse<Category>(fields[2]);
                    products1.Add(new Products(name, price, category));
                }
               
            }
            return products1;
        }
    }
}
