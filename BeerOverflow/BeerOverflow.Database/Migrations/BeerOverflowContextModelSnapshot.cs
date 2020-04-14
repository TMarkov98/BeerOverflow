﻿// <auto-generated />
using System;
using BeerOverflow.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeerOverflow.Database.Migrations
{
    [DbContext(typeof(BeerOverflowContext))]
    partial class BeerOverflowContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerOverflow.Models.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AlcoholByVolume")
                        .HasColumnType("float");

                    b.Property<int>("BreweryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.HasIndex("TypeId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BeerOverflow.Models.BeerDrank", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BeerId");

                    b.HasIndex("BeerId");

                    b.ToTable("BeersDrank");
                });

            modelBuilder.Entity("BeerOverflow.Models.BeerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BeerType");
                });

            modelBuilder.Entity("BeerOverflow.Models.Brewery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BreweryCountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BreweryCountryId");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("BeerOverflow.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnType("char(2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("BeerOverflow.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TargetBeerId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TargetBeerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BeerOverflow.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BanReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BeerOverflow.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("BeerOverflow.Models.WishlistBeer", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BeerId");

                    b.HasIndex("BeerId");

                    b.ToTable("WishlistBeers");
                });

            modelBuilder.Entity("BeerOverflow.Models.Beer", b =>
                {
                    b.HasOne("BeerOverflow.Models.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.BeerType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("BeerOverflow.Models.BeerDrank", b =>
                {
                    b.HasOne("BeerOverflow.Models.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.User", "User")
                        .WithMany("BeersDrank")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Models.Brewery", b =>
                {
                    b.HasOne("BeerOverflow.Models.Country", "BreweryCountry")
                        .WithMany()
                        .HasForeignKey("BreweryCountryId");
                });

            modelBuilder.Entity("BeerOverflow.Models.Review", b =>
                {
                    b.HasOne("BeerOverflow.Models.User", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.Beer", "TargetBeer")
                        .WithMany("Reviews")
                        .HasForeignKey("TargetBeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeerOverflow.Models.User", b =>
                {
                    b.HasOne("BeerOverflow.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");
                });

            modelBuilder.Entity("BeerOverflow.Models.WishlistBeer", b =>
                {
                    b.HasOne("BeerOverflow.Models.Beer", "Beer")
                        .WithMany()
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeerOverflow.Models.User", "User")
                        .WithMany("Wishlist")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
