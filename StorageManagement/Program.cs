using StorageManagement.Entities;
using StorageManagement.Services;
using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Products> test = VerificationService.GetData();
        try
        {
            ProductManagerService productManager = new ProductManagerService();
            VerificationService verification = new VerificationService();
            if(VerificationService.VerificateData() == false)
            {
                Console.WriteLine("There are no registered products, do you want to register?(Y/N)");
                char choice = char.Parse(Console.ReadLine());
                if(choice == 'Y')
                {
                    Console.WriteLine("Quantity:");
                    int quantity = int.Parse(Console.ReadLine());
                    productManager.AddProducts(quantity);
                    verification.WriteInData(productManager.returnList());
                }
            }
            else
            {
                int option = 0;
                while(option != 4)
                {
                    Console.WriteLine("----Product Options----");
                    Console.WriteLine("/1/ --Show products");
                    Console.WriteLine("/2/ -- Change products(not working for now)");
                    Console.WriteLine("/3/ -- Add products");
                    Console.WriteLine("/4/ -- Exit");
                    option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            productManager.UniteData();
                            List<Products> products2 = productManager.returnList();
                            foreach(Products product in products2)
                            {
                                Console.WriteLine(product);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Quantity:");
                            int quantity = int.Parse(Console.ReadLine());
                            productManager.AddProducts(quantity);
                            verification.WriteInData(productManager.returnList());
                            Console.Clear();
                            break;
                    }
                }
            }
        }
        catch (Exception)
        {

        }
    }
}