﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rentalMS2.Models;

namespace rentalMS2.Migrations
{
    [DbContext(typeof(RentalMSDbContext))]
    [Migration("20230822032230_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("rentalMS2.Models.Building", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("BuildingId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("rentalMS2.Models.Chore", b =>
                {
                    b.Property<int>("ChoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOnDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FinishByDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Priority")
                        .HasColumnType("text");

                    b.Property<int?>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("ChoreId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("UnitId");

                    b.ToTable("Chores");
                });

            modelBuilder.Entity("rentalMS2.Models.MaitenanceTask", b =>
                {
                    b.Property<int>("MaitenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("MaitenanceId");

                    b.HasIndex("UnitId");

                    b.ToTable("MaitenanceTasks");
                });

            modelBuilder.Entity("rentalMS2.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ManagerId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("rentalMS2.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BuildingId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("UnitId");

                    b.HasIndex("BuildingId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("rentalMS2.Models.Chore", b =>
                {
                    b.HasOne("rentalMS2.Models.Building", "Building")
                        .WithMany("Chores")
                        .HasForeignKey("BuildingId");

                    b.HasOne("rentalMS2.Models.Manager", "Manager")
                        .WithMany("Chores")
                        .HasForeignKey("ManagerId");

                    b.HasOne("rentalMS2.Models.Unit", "Unit")
                        .WithMany("Chores")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("rentalMS2.Models.MaitenanceTask", b =>
                {
                    b.HasOne("rentalMS2.Models.Unit", "Unit")
                        .WithMany("MaitenanceTasks")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("rentalMS2.Models.Unit", b =>
                {
                    b.HasOne("rentalMS2.Models.Building", "Building")
                        .WithMany("Units")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
