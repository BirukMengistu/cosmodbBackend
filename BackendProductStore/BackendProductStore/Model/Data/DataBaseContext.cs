using Microsoft.EntityFrameworkCore;
using BackendProductStore.Model;
namespace BackendProductStore.Model.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToContainer("Product_Container").HasPartitionKey(x => x.PartitionKey);
        }



        
    }
}
