﻿// <auto-generated />
using System;
using Doss.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Doss.Infra.Migrations
{
    [DbContext(typeof(DossDbContext))]
    [Migration("20231103174922_remove-service-providerid")]
    partial class removeserviceproviderid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Doss")
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Doss.Core.Domain.Addresses.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<Guid?>("ResidentialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("ResidentialId");

                    b.ToTable("Address", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Banks.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bank", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("OnBoardAddress", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("OnBoardServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OnBoardServiceProviderId");

                    b.ToTable("OnBoardPlan", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardResidential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PlanId");

                    b.HasIndex("ServiceProviderId");

                    b.HasIndex("UserId");

                    b.ToTable("OnBoardResidential", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountBank")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AgencyBank")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CoverageArea")
                        .HasColumnType("int");

                    b.Property<Guid?>("OnBoardVehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankId");

                    b.HasIndex("OnBoardVehicleId");

                    b.HasIndex("UserId");

                    b.ToTable("OnBoardServiceProvider", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("varchar(600)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("OnBoardUser", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardVehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("DefaultVehicle")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("OnBoardVehicle", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Plans.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PlanStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ServiceProviderPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ServiceProviderPlanId");

                    b.ToTable("Plans", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.Residential", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CompletedRegistration")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("varchar(600)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Residential", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ResidentialWithServiceProvider", b =>
                {
                    b.Property<Guid>("ResidentialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ResidentialId", "ServiceProviderId", "PlanId");

                    b.HasIndex("PlanId");

                    b.HasIndex("ServiceProviderId");

                    b.ToTable("ResidentialWithServiceProvider", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ServiceProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CompletedRegistration")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("varchar(600)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ServiceProvider", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ServiceProviderPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountBank")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AgencyBank")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CoverageArea")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankId");

                    b.HasIndex("ServiceProviderId");

                    b.ToTable("ServiceProviderPlan", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DefaultVehicle")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid?>("ResidentialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ResidentialId");

                    b.HasIndex("ServiceProviderId");

                    b.ToTable("Vehicle", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Addresses.Address", b =>
                {
                    b.HasOne("Doss.Core.Domain.Users.Residential", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ResidentialId");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardPlan", b =>
                {
                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", null)
                        .WithMany("Plans")
                        .HasForeignKey("OnBoardServiceProviderId");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardResidential", b =>
                {
                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Doss.Core.Domain.Plans.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("Doss.Core.Domain.Users.ServiceProvider", "ServiceProvider")
                        .WithMany()
                        .HasForeignKey("ServiceProviderId");

                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Plan");

                    b.Navigation("ServiceProvider");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", b =>
                {
                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Doss.Core.Domain.Banks.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardVehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("OnBoardVehicleId");

                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Bank");

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Doss.Core.Domain.Plans.Plan", b =>
                {
                    b.HasOne("Doss.Core.Domain.Users.ServiceProviderPlan", null)
                        .WithMany("Plans")
                        .HasForeignKey("ServiceProviderPlanId");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ResidentialWithServiceProvider", b =>
                {
                    b.HasOne("Doss.Core.Domain.Plans.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.Users.Residential", "Residential")
                        .WithMany("ResidentialWithServiceProviders")
                        .HasForeignKey("ResidentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.Users.ServiceProvider", "ServiceProvider")
                        .WithMany()
                        .HasForeignKey("ServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Residential");

                    b.Navigation("ServiceProvider");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ServiceProviderPlan", b =>
                {
                    b.HasOne("Doss.Core.Domain.Addresses.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.Banks.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.Users.ServiceProvider", "ServiceProvider")
                        .WithMany("ServiceProviderPlans")
                        .HasForeignKey("ServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Bank");

                    b.Navigation("ServiceProvider");
                });

            modelBuilder.Entity("Doss.Core.Domain.Vehicles.Vehicle", b =>
                {
                    b.HasOne("Doss.Core.Domain.Users.Residential", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ResidentialId");

                    b.HasOne("Doss.Core.Domain.Users.ServiceProvider", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ServiceProviderId");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.Residential", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ResidentialWithServiceProviders");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ServiceProvider", b =>
                {
                    b.Navigation("ServiceProviderPlans");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Doss.Core.Domain.Users.ServiceProviderPlan", b =>
                {
                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
