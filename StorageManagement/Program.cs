using StorageManagement.Entities;
using StorageManagement.Entities.Enums;
using StorageManagement.Services;
using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {

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
                while(option != 7)
                {
                    Console.WriteLine("----Product Options----");
                    Console.WriteLine("/1/ -- Show products");
                    Console.WriteLine("/2/ -- Change products");
                    Console.WriteLine("/3/ -- Add products");
                    Console.WriteLine("/4/ -- Average price");
                    Console.WriteLine("/5/ -- Clear");
                    Console.WriteLine("/6/ -- Sort products");
                    Console.WriteLine("/7/ -- Exit");
                    option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            productManager.UniteData();
                            List<Products> products2 = productManager.returnList();
                            var groups = products2.GroupBy(p => p.Category);
                            foreach(IGrouping<Category,Products> grop in groups)
                            {
                                Console.WriteLine("----CATEGORY " + grop.Key + "----");
                                foreach(Products product in grop)
                                {
                                    Console.WriteLine(product);
                                }
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            productManager.UniteData();
                            Console.WriteLine();
                            Console.Write("Type product ID:");
                            int id = int.Parse(Console.ReadLine());
                            productManager.ModifyProduct(id);

                            break;
                        case 3:
                            Console.WriteLine("Quantity:");
                            int quantity = int.Parse(Console.ReadLine());
                            productManager.AddProducts(quantity);
                            verification.WriteInData(productManager.returnList());
                            Console.Clear();
                            break;
                        case 4:
                            productManager.UniteData();
                            productManager.AvgPrice();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                        case 6:
                            productManager.UniteData();
                            productManager.SortList();
                            Console.WriteLine();
                            Console.WriteLine("--PRODUCTS SORTED--");
                            Console.WriteLine();

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