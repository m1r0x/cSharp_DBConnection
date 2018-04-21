using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_DBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Entities ctx = new Entities())
            {
                foreach(Category c in ctx.Categories)
                {
                    Console.WriteLine("::::::::" + c.CategoryName + "::::::::");
                    foreach(Product p in c.Products)
                    {
                        Console.WriteLine("+" + p.ProductName);
                    }
                }

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Press Key to add new Product in Category: Bike");
                Console.ReadKey();

                //Neues Produkt erstellen
                Product p1 = new Product();
                p1.CategoryID = 3;
                p1.ProductName = "MX800 Superbike";


                //Neues Produkt in Datenbank speichern
                ctx.Products.Add(p1);
                Console.WriteLine("New Product added");
                //Änderungen speichern
                ctx.SaveChanges();
                Console.WriteLine("Changes saved");

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Press Key to reload Products");
                Console.ReadKey();

                foreach (Category c in ctx.Categories)
                {
                    Console.WriteLine("::::::::" + c.CategoryName + "::::::::");
                    foreach (Product p in c.Products)
                    {
                        Console.WriteLine("+" + p.ProductName);
                    }
                }

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Press Key to Exit");
                Console.ReadKey();
            }
        }
    }
}
