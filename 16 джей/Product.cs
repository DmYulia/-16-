using System.Text.Json.Serialization;

namespace _16_джей
{
    class Product
    {
        int code;
        [JsonPropertyName("Код товара")]
        public int Code
        {
            set
            {
                if (value > 0)
                {
                    code = value;
                }
                else
                {
                    Console.WriteLine("Значение кода должно быть положительным целым числом");
                }
            }
            get
            {
                return code;
            }

        }
        [JsonPropertyName("Название товара")]
        public string Name { get; set; }
        double price;
        [JsonPropertyName("Цена товара")]
        public double Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Цена должна быть положительным числом");
                }
            }
            get
            {
                return price;
            }
        }
    }
}
