using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.Json;

namespace Задача_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../Products.json";
            string text = String.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            Product[] readingProducts = new Product[text.Length];
            readingProducts = JsonSerializer.Deserialize<Product[]>(text);
            Product expensiveProduct = new Product();
            expensiveProduct = readingProducts[0];
            foreach (Product p in readingProducts)
            {
                if (p.Cost> expensiveProduct.Cost)
                    expensiveProduct = p;
            }
            Console.WriteLine($" Название самого дорого товара - {expensiveProduct.Name}");
            Console.ReadKey();
        }
    }
}
