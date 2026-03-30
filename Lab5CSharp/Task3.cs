using System;
using System.Linq;

namespace Lab5
{
    public class Task3
    {
        public static void Execute()
        {
            Product[] products = new Product[]
            {
                new Toy("Lego", 49.99m, 8, "Lego Inc", "Plastic"),
                new Book("C# Programming", 29.99m, 16, "John Doe", "TechPress"),
                new SportsEquipment("Football", 19.99m, 10, "Adidas"),
                new Toy("Teddy Bear", 15.50m, 3, "KidsToys", "Plush")
            };

            Console.WriteLine("--- All Products ---");
            foreach (var p in products) p.Show();

            Console.Write("\nEnter product type to search (Toy/Book/SportsEquipment): ");
            string searchType = Console.ReadLine()!;

            Console.WriteLine($"\n--- Search Results for '{searchType}' ---");
            var found = products.Where(p => p.IsType(searchType)).ToArray();
            
            if (found.Length > 0)
            {
                foreach (var p in found) p.Show();
            }
            else
            {
                Console.WriteLine("No products found of this type.");
            }
        }
    }

    public abstract class Product
    {
        protected string name;
        protected decimal price;
        protected int targetAge;

        public Product(string name, decimal price, int targetAge)
        {
            this.name = name;
            this.price = price;
            this.targetAge = targetAge;
        }

        public abstract void Show();
        public abstract bool IsType(string typeName);
    }

    public class Toy : Product
    {
        protected string manufacturer;
        protected string material;

        public Toy(string name, decimal price, int targetAge, string manufacturer, string material) 
            : base(name, price, targetAge)
        {
            this.manufacturer = manufacturer;
            this.material = material;
        }

        public override void Show()
        {
            Console.WriteLine($"[Toy] Name: {name}, Price: ${price}, Age: {targetAge}+, Maker: {manufacturer}, Material: {material}");
        }

        public override bool IsType(string typeName) => typeName.Equals("Toy", StringComparison.OrdinalIgnoreCase);
    }

    public class Book : Product
    {
        protected string author;
        protected string publisher;

        public Book(string name, decimal price, int targetAge, string author, string publisher) 
            : base(name, price, targetAge)
        {
            this.author = author;
            this.publisher = publisher;
        }

        public override void Show()
        {
            Console.WriteLine($"[Book] Title: {name}, Price: ${price}, Age: {targetAge}+, Author: {author}, Publisher: {publisher}");
        }

        public override bool IsType(string typeName) => typeName.Equals("Book", StringComparison.OrdinalIgnoreCase);
    }

    public class SportsEquipment : Product
    {
        protected string manufacturer;

        public SportsEquipment(string name, decimal price, int targetAge, string manufacturer) 
            : base(name, price, targetAge)
        {
            this.manufacturer = manufacturer;
        }

        public override void Show()
        {
            Console.WriteLine($"[SportsEquipment] Name: {name}, Price: ${price}, Age: {targetAge}+, Maker: {manufacturer}");
        }

        public override bool IsType(string typeName) => typeName.Equals("SportsEquipment", StringComparison.OrdinalIgnoreCase);
    }
}