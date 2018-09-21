using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductModel P = new ProductModel();
            //Ex_1
            Console.WriteLine("1.List all the categories.");
            Console.WriteLine("-----------------------------");

            foreach (var item in P.Categorys)
            {
                Console.WriteLine("{0}, {1}",item.Id ,item.Description);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //Ex_2
            Console.WriteLine("2.List all the Products");
            Console.WriteLine("-----------------------------");

            foreach (var item in P.Products)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}", 
                    item.ProductID, item.Description,item.QuantityInStock,item.UnitPrice,item.CategoryID);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //Ex_3
            Console.WriteLine("3.List Products with a Quantity <= 100 ");
            Console.WriteLine("-----------------------------");

            foreach (var item in P.Products)
            {
                if(item.QuantityInStock<=100)
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                    item.ProductID, item.Description, item.QuantityInStock, item.UnitPrice, item.CategoryID);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //Ex_4
            Console.WriteLine("4.List all the Products together with their total value");
            Console.WriteLine("-----------------------------");

            foreach (var item in P.Products)
            {
                float totalValue = item.QuantityInStock * item.UnitPrice;
                    Console.WriteLine("{0}, {1}, {2}, Total value: {3}",
                        item.ProductID, item.Description, item.CategoryID, totalValue);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            //Ex_5
            Console.WriteLine("5.List all the Products in the Hardware Category");
            Console.WriteLine("-----------------------------");

            foreach (var item in P.Products)
            {
                if (item.CategoryID == 1)
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}",
                        item.ProductID, item.Description, item.QuantityInStock, item.UnitPrice, item.CategoryID);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();


            //Ex_6
            Console.WriteLine("6.	List all the suppliers and their Parts ordered by supplier name");
            Console.WriteLine("-----------------------------");

            

            var join = (from s in P.Suppliers
                        join sp in P.SupplierProducts
                        on s.SupplierID equals sp.SupplierID
                          join p in P.Products
                        on sp.ProductID equals p.ProductID
                        orderby s.SupplierName
                        select new
                        {
                            Product = p.Description,
                            Description = p.Description,
                            SupplierID = s.SupplierID,
                            SupplierName = s.SupplierName

                        });

            int CurrentSupplierId = join.First().SupplierID;
            Console.WriteLine("Product List for {0},{1}", join.First().SupplierID, join.First().SupplierName);
            foreach (var item in join)
            {
                if (item.SupplierID!=CurrentSupplierId)
                {

                    Console.WriteLine("Product List for {0},{1}", join.First().SupplierID, join.First().SupplierName);
                    CurrentSupplierId = item.SupplierID;
                }

                Console.WriteLine(item.Product);
            }

            








            Console.WriteLine("-----------------------------");
            Console.WriteLine();

            Console.ReadLine();
        }
    }

    
}
