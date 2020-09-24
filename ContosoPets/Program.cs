namespace ContosoPets
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    class Program
    {
        static void Main()
        {
            using ContosoPetsContext context = new ContosoPetsContext();

            SeedDb(context);

            RetrieveProducts(context);

            var product = GetProduct(context);
            UpdateProduct(context, product);
            RetrieveProducts(context);

            DeleteProduct(context, product);
            RetrieveProducts(context);
        }

        private static void DeleteProduct(ContosoPetsContext context, Product product)
        {
            if (product != null)
                context.Remove(product);

            context.SaveChanges();
        }

        private static void UpdateProduct(ContosoPetsContext context, Product product)
        {
            if (product != null)
                product.Price = 7.99m;

            context.SaveChanges();
        }

        private static Product GetProduct(ContosoPetsContext context)
        {
            return context.Products
                .FirstOrDefault(p => p.Name == "Squeaky Dog Bone");
        }

        private static void RetrieveProducts(ContosoPetsContext context)
        {
            var products = context.Products
                .Where(p => p.Price > 5.00m)
                .OrderBy(p => p.Name);

            foreach (Product p in products)
            {
                Console.WriteLine($"Id:    {p.Id}");
                Console.WriteLine($"Name:  {p.Name}");
                Console.WriteLine($"Price: {p.Price}");
                Console.WriteLine(new string('-', 20));
            }
            Console.WriteLine();
        }

        private static void SeedDb(ContosoPetsContext context)
        {
            context.Database.ExecuteSqlRaw("DELETE FROM dbo.Products");
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('dbo.Products', RESEED, 0)");

            Product squeakyBone = new Product
            {
                Name = "Squeaky Dog Bone",
                Price = 4.99M
            };
            context.Products.Add(squeakyBone);

            Product tennisBalls = new Product
            {
                Name = "Tennis Ball 3-Pack",
                Price = 9.99M
            };
            context.Add(tennisBalls);

            context.SaveChanges();
        }
    }
}
