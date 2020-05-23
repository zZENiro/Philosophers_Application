﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Philosophers_Application.Data;

namespace Philosophers_Application.Migrations
{
    [DbContext(typeof(PhilosophersDbContext))]
    [Migration("20200523203613_initDbSeed")]
    partial class initDbSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Philosophers_Application.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("countries_tbl");
                });

            modelBuilder.Entity("Philosophers_Application.Models.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DirectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("directions_tbl");
                });

            modelBuilder.Entity("Philosophers_Application.Models.Philosopher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("PhilosopherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("philosophers_tbl");
                });

            modelBuilder.Entity("Philosophers_Application.Models.PhilosopherDirection", b =>
                {
                    b.Property<int>("DirectionId")
                        .HasColumnType("int");

                    b.Property<int>("PhilosopherId")
                        .HasColumnType("int");

                    b.HasKey("DirectionId", "PhilosopherId")
                        .HasName("Name");

                    b.HasIndex("PhilosopherId");

                    b.ToTable("PhilosopherDirection");
                });

            modelBuilder.Entity("Philosophers_Application.Models.Philosopher", b =>
                {
                    b.HasOne("Philosophers_Application.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Philosophers_Application.Models.PhilosopherDirection", b =>
                {
                    b.HasOne("Philosophers_Application.Models.Direction", "Direction")
                        .WithMany("PhilosopherDirection")
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Philosophers_Application.Models.Philosopher", "Philosopher")
                        .WithMany("PhilosopherDirection")
                        .HasForeignKey("PhilosopherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
