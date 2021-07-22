﻿// <auto-generated />
using System;
using EventsWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventsWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210706163528_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventsWebsite.Model.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Directors")
                        .HasColumnType("text");

                    b.Property<string>("Genres")
                        .HasColumnType("text");

                    b.Property<decimal>("IMDbRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieCertificate")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("MovieDescription")
                        .HasColumnType("text");

                    b.Property<string>("MovieImage")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("MoviePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MovieTitle")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NumVotesIMDb")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RunTime")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}