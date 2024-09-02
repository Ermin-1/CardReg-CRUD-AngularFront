using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CardReg_CRUD_AngularFront.Models
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options)
        {
            
        }

       public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>().HasData(new Card()
            {
                Id = Guid.NewGuid(),
                CardNumber = "39483843499999",
                CVC = 123,
                ExpireMonth = 1,
                ExpireYear = 2026,
                HolderName = "Ermin Husic"
            });

            modelBuilder.Entity<Card>().HasData(new Card()
            {
                Id = Guid.NewGuid(),
                CardNumber = "5234567890123456",
                CVC = 456,
                ExpireMonth = 2,
                ExpireYear = 2025,
                HolderName = "Anna Svensson"
            });

            modelBuilder.Entity<Card>().HasData(new Card()
            {
                Id = Guid.NewGuid(),
                CardNumber = "6011123456789012",
                CVC = 789,
                ExpireMonth = 3,
                ExpireYear = 2024,
                HolderName = "Björn Karlsson"
            });

            modelBuilder.Entity<Card>().HasData(new Card()
            {
                Id = Guid.NewGuid(),
                CardNumber = "4000056655665556",
                CVC = 321,
                ExpireMonth = 4,
                ExpireYear = 2027,
                HolderName = "Caroline Lindberg"
            });

            modelBuilder.Entity<Card>().HasData(new Card()
            {
                Id = Guid.NewGuid(),
                CardNumber = "3566002020360505",
                CVC = 654,
                ExpireMonth = 5,
                ExpireYear = 2023,
                HolderName = "David Ek"
            });


        }
    }
}
