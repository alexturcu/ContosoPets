namespace ContosoPets.Data
{
    using System.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ContosoPetsContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var contosoConnection = ConfigurationManager.ConnectionStrings["ContosoConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(contosoConnection);
        }
    }
}
