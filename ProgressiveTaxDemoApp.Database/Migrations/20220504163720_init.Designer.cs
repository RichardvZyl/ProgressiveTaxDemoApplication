﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgressiveTaxDemoApp.Database;

#nullable disable

namespace ProgressiveTaxDemoApp.Database.Migrations
{
    [DbContext(typeof(ProgressiveTaxDatabase))]
    [Migration("20220504163720_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProgressiveTaxDemoApp.Domain.ProgressiveTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("From")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProgressiveTax", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            From = 0,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4146), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 10
                        },
                        new
                        {
                            Id = 2,
                            From = 8351,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4148), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 15
                        },
                        new
                        {
                            Id = 3,
                            From = 33951,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4148), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 25
                        },
                        new
                        {
                            Id = 4,
                            From = 82251,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 28
                        },
                        new
                        {
                            Id = 5,
                            From = 171151,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4149), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 33
                        },
                        new
                        {
                            Id = 6,
                            From = 372951,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4150), new TimeSpan(0, 0, 0, 0, 0)),
                            Rate = 35
                        });
                });

            modelBuilder.Entity("ProgressiveTaxDemoApp.Domain.TaxCalculationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TaxType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TaxCalculationType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4169), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "7441",
                            TaxType = 0
                        },
                        new
                        {
                            Id = 2,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4170), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "A100",
                            TaxType = 1
                        },
                        new
                        {
                            Id = 3,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "7000",
                            TaxType = 2
                        },
                        new
                        {
                            Id = 4,
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4171), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "1000",
                            TaxType = 0
                        });
                });

            modelBuilder.Entity("ProgressiveTaxDemoApp.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTimeOffset>("LastUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("DECIMAL(9,2)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2310db8a-c813-45f1-bd76-7e95a748d70b"),
                            Email = "example@example.com",
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(3950), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "7441",
                            Salary = 1000000m
                        },
                        new
                        {
                            Id = new Guid("d0be9e66-9541-4c06-b4ce-8b3c3e145b31"),
                            Email = "test@test.com",
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(3963), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "A100",
                            Salary = 130000m
                        },
                        new
                        {
                            Id = new Guid("ceb06110-9fd7-4a77-bdb0-1268d76e4c18"),
                            Email = "test@example.com",
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4111), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "7000",
                            Salary = 10000m
                        },
                        new
                        {
                            Id = new Guid("e941d7a4-4d46-4f09-8d52-a6585279998b"),
                            Email = "example@test.com",
                            LastUpdated = new DateTimeOffset(new DateTime(2022, 5, 4, 16, 37, 20, 215, DateTimeKind.Unspecified).AddTicks(4113), new TimeSpan(0, 0, 0, 0, 0)),
                            PostalCode = "1000",
                            Salary = 100000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}