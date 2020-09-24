using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContosoPetsWeb.Models
{
    public partial class ContosoPetsContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ContosoPetsContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContosoPetsContext(DbContextOptions<ContosoPetsContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductOrders> ProductOrders { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Email).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);
            });

            modelBuilder.Entity<ProductOrders>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.ProductId);
            });
        }
    }
}
