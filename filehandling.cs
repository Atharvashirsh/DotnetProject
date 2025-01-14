using System;
using System.Collections.Generic;
using System.IO;

namespace ProductApp
{
    // Product class
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id},{Name},{Price}";
        }

        public static Product Parse(string line)
        {
            var parts = line.Split(',');
            return new Product(
                int.Parse(parts[0]),
                parts[1],
                decimal.Parse(parts[2])
            );
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "products.txt";

            // Adding some products
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", 75000.50m),
                new Product(2, "Smartphone", 25000.75m),
                new Product(3, "Headphones", 3000.99m)
            };

            // Writing products to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine(product.ToString());
                }
            }

            Console.WriteLine("Products written to file.");

            // Reading products from the file
            List<Product> loadedProducts = new List<Product>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    loadedProducts.Add(Product.Parse(line));
                }
            }

            Console.WriteLine("Products read from file:");
            foreach (var product in loadedProducts)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
    }
}
