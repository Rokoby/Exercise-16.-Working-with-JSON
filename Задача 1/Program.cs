using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Задача_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numberOfProfucts = 5;
            Product[] products = new Product[numberOfProfucts];
            for (int i = 0; i < numberOfProfucts; i++)
            {
                Console.WriteLine("Введите код");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите наименование");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену");
                double cost = Convert.ToDouble(Console.ReadLine());
                products[i] = new Product { Code = code, Name = name, Cost = cost };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(products, options);
            string path = "../../../Products.json";
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(json);
            }

        }
    }
}
