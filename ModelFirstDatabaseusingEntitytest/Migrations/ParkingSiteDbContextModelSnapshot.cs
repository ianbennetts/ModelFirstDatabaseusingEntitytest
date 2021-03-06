﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelFirstDatabaseusingEntitytest.Services;

namespace ModelFirstDatabaseusingEntitytest.Migrations
{
    [DbContext(typeof(ParkingSiteDbContext))]
    partial class ParkingSiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelFirstDatabaseusingEntitytest.Models.ParkingArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ParkingAreas");
                });

            modelBuilder.Entity("ModelFirstDatabaseusingEntitytest.Models.ParkingSite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("API")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("NumberOfSpaces")
                        .HasColumnType("int");

                    b.Property<string>("Parm1")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Parm2")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Parm3")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ParkingSite");
                });

            modelBuilder.Entity("ModelFirstDatabaseusingEntitytest.Models.SiteArea", b =>
                {
                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.HasKey("SiteId", "AreaId");

                    b.HasIndex("AreaId");

                    b.ToTable("SiteArea");
                });

            modelBuilder.Entity("ModelFirstDatabaseusingEntitytest.Models.SiteArea", b =>
                {
                    b.HasOne("ModelFirstDatabaseusingEntitytest.Models.ParkingArea", "ParkingArea")
                        .WithMany("SiteAreas")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModelFirstDatabaseusingEntitytest.Models.ParkingSite", "ParkingSite")
                        .WithMany("SiteAreas")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
