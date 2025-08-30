using StorageManagement.Entities;
using StorageManagement.Entities.Enums;
using System.Globalization;
using System.IO;
namespace StorageManagement.Services
{
    internal class VerificationService
    {


        public static bool VerificateData()
        {
            string path = GetPath();
            FileInfo data = new FileInfo(path);
            if (data.Length == 0 || !File.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ChangeData(Products product)
        {
            string path = GetPath();
            var lines = File.ReadAllLines(path).ToList(); 
            for (int i = 0; i < lines.Count; i++)
            {
                string[] fields = lines[i].Split(",");
                int id = int.Parse(fields[3]);
                if (product.Id == id)
                {
                    lines[i] = product.ToString(); 
                    break;
                }
            }
            File.WriteAllLines(path, lines); 
        }

        public void WriteInData(List<Products> list)
        {
            string path = GetPath();
            Console.WriteLine("ESCREVENDO DADOS");
            using (StreamWriter sw = new StreamWriter(path,false))
            {
                foreach (Products obj in list)
                {
                    sw.WriteLine(obj);
                }
            }
        }
        public static List<Products> GetData()
        {
            string path = GetPath();
            List<Products> products1 = new List<Products>();
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(",");
                    string name = fields[0];
                    double price = double.Parse(fields[1], System.Globalization.CultureInfo.InvariantCulture);
                    Category category = Enum.Parse<Category>(fields[2]);
                    int id = int.Parse(fields[3]);
                    products1.Add(new Products(name, price, category,id));
                }
               
            }
            return products1;
        }

        public static string GetPath()
        {
            string dataname = "data.txt";
            string directory = AppContext.BaseDirectory;
            string path = Path.Combine(directory, dataname);

            return path;

        }
    }
}
