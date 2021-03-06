// <auto-generated />
using CaDeiGreciWebsite.Data.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaDeiGreciWebsite.Data.Menu.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20220416211654_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Menu")
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories", "Menu");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.CategoryPriceKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoriesPriceKind", "Menu");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items", "Menu");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("MenuPriceKindId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("MenuPriceKindId");

                    b.ToTable("Prices", "Menu");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.CategoryPriceKind", b =>
                {
                    b.HasOne("CaDeiGreciWebsite.Data.Menu.Category", "Category")
                        .WithMany("PriceKinds")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Item", b =>
                {
                    b.HasOne("CaDeiGreciWebsite.Data.Menu.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Price", b =>
                {
                    b.HasOne("CaDeiGreciWebsite.Data.Menu.Item", "MenuItem")
                        .WithMany("Prices")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CaDeiGreciWebsite.Data.Menu.CategoryPriceKind", "MenuPriceKind")
                        .WithMany("Prices")
                        .HasForeignKey("MenuPriceKindId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("MenuPriceKind");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Category", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("PriceKinds");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.CategoryPriceKind", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("CaDeiGreciWebsite.Data.Menu.Item", b =>
                {
                    b.Navigation("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
