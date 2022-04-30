using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaDeiGreciWebsite.Data.Menu
{
    // dotnet ef migrations add -c CaDeiGreciWebsite.Data.Menu.DbContext -OutputDir Data\Menu\Migrations
    // dotnet ef migrations remove -c CaDeiGreciWebsite.Data.Menu.DbContext
    // dotnet ef database update <0|'name'|null> -c CaDeiGreciWebsite.Data.Menu.DbContext

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPriceKind> CategoriesPriceKind { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<ItemQuality> ItemQualities { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<ItemAllergen> ItemAllergens { get; set; }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema($"{nameof(CaDeiGreciWebsite.Data.Menu)}");
            modelBuilder.Entity<Category>(x => x.HasMany(y => y.Items).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict));
            modelBuilder.Entity<Category>(x => x.HasMany(y => y.PriceKinds).WithOne(x => x.Category).OnDelete(DeleteBehavior.Restrict));
            modelBuilder.Entity<Item>(x => x.HasMany(y => y.Prices).WithOne(y => y.MenuItem).OnDelete(DeleteBehavior.Restrict));
            modelBuilder.Entity<CategoryPriceKind>(x => x.HasMany(y => y.Prices).WithOne(y => y.MenuPriceKind).OnDelete(DeleteBehavior.Restrict));
            modelBuilder.Entity<Quality>()
                .HasMany(q => q.Items)
                .WithMany(i => i.Qualities)
                .UsingEntity<ItemQuality>(
                    j => j.HasOne(iq => iq.Item).WithMany(i => i.ItemQualities).HasForeignKey(iq => iq.ItemId),
                    j => j.HasOne(iq => iq.Quality).WithMany(q => q.ItemsQuality).HasForeignKey(iq => iq.QualityId),
                    j =>
                    {
                        j.Property(iq => iq.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        j.HasKey(iq => new { iq.ItemId, iq.QualityId });
                    })
                .HasData(
                    new Quality() { Id = 01, Name = "bio" },
                    new Quality() { Id = 02, Name = "locally grown" },
                    new Quality() { Id = 03, Name = "vegan" },
                    new Quality() { Id = 04, Name = "vegetarian" }
                );
            modelBuilder.Entity<Allergen>()
               .HasMany(a => a.Items)
               .WithMany(i => i.Allergens)
               .UsingEntity<ItemAllergen>(
                   j => j.HasOne(ia => ia.Item).WithMany(i => i.ItemAllergens).HasForeignKey(iq => iq.ItemId),
                   j => j.HasOne(ia => ia.Allergen).WithMany(q => q.ItemsAllergen).HasForeignKey(iq => iq.AllergenId),
                   j =>
                   {
                       j.Property(ia => ia.CreationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                       j.HasKey(ia => new { ia.ItemId, ia.AllergenId });
                   })
               .HasData(
                    new Allergen() { Id = 01, Name = "Dairy" },
                    new Allergen() { Id = 02, Name = "Eggs" },
                    new Allergen() { Id = 03, Name = "Fish" },
                    new Allergen() { Id = 04, Name = "Gluten" },
                    new Allergen() { Id = 05, Name = "Legumes" },
                    new Allergen() { Id = 06, Name = "Peanut" },
                    new Allergen() { Id = 07, Name = "Seeds" },
                    new Allergen() { Id = 08, Name = "Shellfish" },
                    new Allergen() { Id = 09, Name = "Treenuts" },
                    new Allergen() { Id = 10, Name = "Corn" }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
