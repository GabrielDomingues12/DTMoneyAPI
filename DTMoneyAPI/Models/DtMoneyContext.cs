using Microsoft.EntityFrameworkCore;

namespace DTMoneyAPI.Models
{
    public class DtMoneyContext : DbContext
    {
        public DtMoneyContext(DbContextOptions<DtMoneyContext> options) : base(options) { }

        public DbSet<DtMoneyModel> dtMoneyModels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtMoneyModel>(entity =>
            {
                entity.Property(e => e.Preco).HasColumnType("decimal(18,2)");
            });
        }
    }
}
