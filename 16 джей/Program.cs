using static System.Console;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace _16_джей
{
    class Program
    {
        static void Main(string[] args)
        {
            string q = "";
        Zero:
            WriteLine("             Введите код необходимого пункта меню:");
            WriteLine("1 - Задача 1.");
            WriteLine("2 - Задача 2.");
            WriteLine("q - Выход из программы.");
        Begin:
            try
            {
                q = ReadLine();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                goto Begin;
            }
            switch (q)
            {
                case "1":
                    const int n = 5;
                    Product[] product = new Product[n];
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Введите код товара");
                        int code = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите название товара");
                        string? name = ReadLine();
                        Console.WriteLine("Введите цену товара");
                        double price = Convert.ToDouble(Console.ReadLine());
                        product[i] = new Product() { Code = code, Name = name, Price = price };
                    }
                    JsonSerializerOptions options = new JsonSerializerOptions()
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                        WriteIndented = true
                    };
                    string jsonString = JsonSerializer.Serialize(product, options);
                    using (StreamWriter sw = new StreamWriter("../../../Products.json"))
                    {
                        sw.Write(jsonString);
                    }
                    WriteLine("");
                    goto Zero;
                case "2":
                    StreamReader sr = new StreamReader("../../../Products.json");
                    string jsonstring1 = sr.ReadToEnd();
                    Product[] product1 = JsonSerializer.Deserialize<Product[]>(jsonstring1);
                    Console.WriteLine(jsonstring1);
                    Product maxPrice = product1[0];
                    foreach (Product p in product1)
                    {
                        if (p.Price > maxPrice.Price)
                        {
                            maxPrice = p;
                        }
                    }
                    Console.WriteLine($"{maxPrice.Code} {maxPrice.Name} {maxPrice.Price}");
                    WriteLine("");
                    goto Zero;
                case "q":
                    goto End;
                default:
                    WriteLine("Введен несуществующий код пункта меню!");
                    goto Begin;
            }
        End:
            WriteLine();
        }
    }
}
