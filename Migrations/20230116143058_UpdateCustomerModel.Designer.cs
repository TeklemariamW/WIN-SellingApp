﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WIN_sellingApp.Data;

#nullable disable

namespace WINsellingApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230116143058_UpdateCustomerModel")]
    partial class UpdateCustomerModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("WIN_sellingApp.Models.Car", b =>
                {
                    b.Property<int>("Carid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarModel")
                        .HasColumnType("INTEGER");

                    b.Property<float>("KMStand")
                        .HasColumnType("REAL");

                    b.Property<string>("KindOfCar")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Saleform")
                        .HasColumnType("TEXT");

                    b.HasKey("Carid");

                    b.ToTable("cars");
                });

            modelBuilder.Entity("WIN_sellingApp.Models.Customer", b =>
                {
                    b.Property<int>("Customerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TelephoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Customerid");

                    b.ToTable("customers");
                });
#pragma warning restore 612, 618
        }
    }
}
