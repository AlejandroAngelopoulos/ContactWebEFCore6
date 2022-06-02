﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyContactManagerData;

#nullable disable

namespace MyContactManagerData.Migrations
{
    [DbContext(typeof(MyContactManagerDBContext))]
    partial class MyContactManagerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ContactWebModels.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhonePrimary")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PhoneSecondary")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("StreetAddress2")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactWebModels.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "AT",
                            Name = "Attica"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "AC",
                            Name = "Achaia"
                        },
                        new
                        {
                            Id = 3,
                            Abbreviation = "TH",
                            Name = "Thessaloniki"
                        },
                        new
                        {
                            Id = 4,
                            Abbreviation = "IR",
                            Name = "Irakleiou"
                        });
                });

            modelBuilder.Entity("ContactWebModels.Contact", b =>
                {
                    b.HasOne("ContactWebModels.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
