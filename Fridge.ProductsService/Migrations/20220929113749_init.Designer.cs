﻿// <auto-generated />
using System;
using Fridge.ProductsService.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fridge.ProductsService.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20220929113749_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fridge.Shared.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5edcdb18-b675-4ccb-ba7f-d68226a939f5"),
                            DefaultQuantity = 5,
                            ImageSource = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg",
                            Name = "Bread"
                        },
                        new
                        {
                            Id = new Guid("d4473a8a-c8bc-4aa1-9488-2daee630476f"),
                            DefaultQuantity = 10,
                            ImageSource = "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg",
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("fbfc3635-0579-4eb4-917b-1fcdd789afea"),
                            DefaultQuantity = 15,
                            ImageSource = "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg",
                            Name = "Cheese"
                        },
                        new
                        {
                            Id = new Guid("71fe1cf5-db7b-4be2-9f6f-b3dcd45f3023"),
                            DefaultQuantity = 11,
                            ImageSource = "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg",
                            Name = "Mashroom"
                        },
                        new
                        {
                            Id = new Guid("dd36a942-f381-49cf-b66b-b34cd8ebbf7a"),
                            DefaultQuantity = 3,
                            ImageSource = "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg",
                            Name = "Fish"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
