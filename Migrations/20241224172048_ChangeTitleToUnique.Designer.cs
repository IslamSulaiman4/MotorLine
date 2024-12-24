﻿// <auto-generated />
using System;
using EntityFrameworkCore.Jet.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotorLine.Data;

#nullable disable

namespace MotorLine.Migrations
{
    [DbContext(typeof(AdsDbContext))]
    [Migration("20241224172048_ChangeTitleToUnique")]
    partial class ChangeTitleToUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Jet:ValueGenerationStrategy", JetValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MotorLine.Models.Ad", b =>
                {
                    b.Property<int>("AdID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Jet:ValueGenerationStrategy", JetValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("Photo1")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<string>("Photo2")
                        .HasColumnType("longchar");

                    b.Property<string>("Photo3")
                        .HasColumnType("longchar");

                    b.Property<string>("Photo4")
                        .HasColumnType("longchar");

                    b.Property<string>("Photo5")
                        .HasColumnType("longchar");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longchar");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("AdID");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Ads");
                });
#pragma warning restore 612, 618
        }
    }
}
