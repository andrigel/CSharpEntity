﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EFDBContext))]
    [Migration("20190919202817_Init0")]
    partial class Init0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entityes.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("DataLayer.Entityes.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("book");
                });

            modelBuilder.Entity("DataLayer.Entityes.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<DateTime>("DateOfReturn");

                    b.Property<int?>("ReaderId");

                    b.HasKey("LogId");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("log");
                });

            modelBuilder.Entity("DataLayer.Entityes.Reader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("District");

                    b.Property<string>("Name");

                    b.Property<string>("Patronymic");

                    b.Property<string>("Region");

                    b.Property<string>("Surname");

                    b.Property<string>("Telephone");

                    b.Property<int>("TicketNumber");

                    b.HasKey("Id");

                    b.ToTable("reader");
                });

            modelBuilder.Entity("DataLayer.Entityes.Book", b =>
                {
                    b.HasOne("DataLayer.Entityes.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataLayer.Entityes.Log", b =>
                {
                    b.HasOne("DataLayer.Entityes.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("DataLayer.Entityes.Reader", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId");
                });
#pragma warning restore 612, 618
        }
    }
}
