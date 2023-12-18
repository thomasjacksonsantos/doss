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
    [Migration("20231218185522_aumentar-limite-verification-status")]
    partial class aumentarlimiteverificationstatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Doss")
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

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

                    b.Property<Guid>("OnBoardUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceProviderPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("TokenUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OnBoardUserId");

                    b.HasIndex("PlanId");

                    b.HasIndex("ServiceProviderPlanId");

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

                    b.Property<Guid>("OnBoardUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OnBoardVehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("TokenUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankId");

                    b.HasIndex("OnBoardUserId");

                    b.HasIndex("OnBoardVehicleId");

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

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

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

                    b.ToTable("Plan", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.Residential", b =>
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

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Residential", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialVerificationRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("ResidentialWithServiceProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResidentialWithServiceProviderId");

                    b.ToTable("ResidentialVerificationRequest", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialVerificationRequest+VerificationMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResidentialVerificationRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ResidentialVerificationRequestId");

                    b.ToTable("VerificationMessage", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialWithServiceProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResidentialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServiceProviderPlanId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("ResidentialId");

                    b.HasIndex("ServiceProviderPlanId");

                    b.ToTable("ResidentialWithServiceProvider", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.ServiceProviders.ServiceProvider", b =>
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

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ServiceProvider", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.ServiceProviders.ServiceProviderAlert", b =>
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

                    b.HasKey("Id");

                    b.ToTable("ServiceProviderAlert", "Doss");
                });

            modelBuilder.Entity("Doss.Core.Domain.ServiceProviders.ServiceProviderPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountBank")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)");

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

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardPlan", b =>
                {
                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", null)
                        .WithMany("Plans")
                        .HasForeignKey("OnBoardServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardResidential", b =>
                {
                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardUser", "OnBoardUser")
                        .WithMany()
                        .HasForeignKey("OnBoardUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.Plans.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("Doss.Core.Domain.ServiceProviders.ServiceProviderPlan", "ServiceProviderPlan")
                        .WithMany()
                        .HasForeignKey("ServiceProviderPlanId");

                    b.OwnsOne("Doss.Core.Domain.OnBoard.OnBoardTermsAccept", "TermsAccept", b1 =>
                        {
                            b1.Property<Guid>("OnBoardResidentialId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DateTimeAccept")
                                .HasColumnType("datetime2")
                                .HasColumnName("DateTimeAccept");

                            b1.Property<bool>("TermsAccept")
                                .HasColumnType("bit")
                                .HasColumnName("TermsAccept");

                            b1.HasKey("OnBoardResidentialId");

                            b1.ToTable("OnBoardResidential", "Doss");

                            b1.WithOwner()
                                .HasForeignKey("OnBoardResidentialId");
                        });

                    b.Navigation("Address");

                    b.Navigation("OnBoardUser");

                    b.Navigation("Plan");

                    b.Navigation("ServiceProviderPlan");

                    b.Navigation("TermsAccept");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", b =>
                {
                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardAddress", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Doss.Core.Domain.Banks.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardUser", "OnBoardUser")
                        .WithMany()
                        .HasForeignKey("OnBoardUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.OnBoard.OnBoardVehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("OnBoardVehicleId");

                    b.OwnsOne("Doss.Core.Domain.OnBoard.OnBoardTermsAccept", "TermsAccept", b1 =>
                        {
                            b1.Property<Guid>("OnBoardServiceProviderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DateTimeAccept")
                                .HasColumnType("datetime2")
                                .HasColumnName("DateTimeAccept");

                            b1.Property<bool>("TermsAccept")
                                .HasColumnType("bit")
                                .HasColumnName("TermsAccept");

                            b1.HasKey("OnBoardServiceProviderId");

                            b1.ToTable("OnBoardServiceProvider", "Doss");

                            b1.WithOwner()
                                .HasForeignKey("OnBoardServiceProviderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Bank");

                    b.Navigation("OnBoardUser");

                    b.Navigation("TermsAccept");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Doss.Core.Domain.Plans.Plan", b =>
                {
                    b.HasOne("Doss.Core.Domain.ServiceProviders.ServiceProviderPlan", null)
                        .WithMany("Plans")
                        .HasForeignKey("ServiceProviderPlanId");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialVerificationRequest", b =>
                {
                    b.HasOne("Doss.Core.Domain.Residentials.ResidentialWithServiceProvider", "ResidentialWithServiceProvider")
                        .WithMany()
                        .HasForeignKey("ResidentialWithServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResidentialWithServiceProvider");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialVerificationRequest+VerificationMessage", b =>
                {
                    b.HasOne("Doss.Core.Domain.Residentials.ResidentialVerificationRequest", null)
                        .WithMany("Messages")
                        .HasForeignKey("ResidentialVerificationRequestId");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialWithServiceProvider", b =>
                {
                    b.HasOne("Doss.Core.Domain.Plans.Plan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.Residentials.Residential", "Residential")
                        .WithMany("ResidentialWithServiceProviders")
                        .HasForeignKey("ResidentialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.ServiceProviders.ServiceProviderPlan", "ServiceProviderPlan")
                        .WithMany()
                        .HasForeignKey("ServiceProviderPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Doss.Core.Domain.Addresses.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ResidentialWithServiceProviderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar(30)")
                                .HasColumnName("Address_City");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Address_Complement");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_Country");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Address_Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Address_Longitude");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Address_Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_ZipCode");

                            b1.HasKey("ResidentialWithServiceProviderId");

                            b1.ToTable("ResidentialWithServiceProvider", "Doss");

                            b1.WithOwner()
                                .HasForeignKey("ResidentialWithServiceProviderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Residential");

                    b.Navigation("ServiceProviderPlan");
                });

            modelBuilder.Entity("Doss.Core.Domain.ServiceProviders.ServiceProviderPlan", b =>
                {
                    b.HasOne("Doss.Core.Domain.Banks.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doss.Core.Domain.ServiceProviders.ServiceProvider", "ServiceProvider")
                        .WithMany("ServiceProviderPlans")
                        .HasForeignKey("ServiceProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Doss.Core.Domain.Addresses.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ServiceProviderPlanId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar(30)")
                                .HasColumnName("Address_City");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Address_Complement");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_Country");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Address_Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Address_Longitude");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Address_Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Address_ZipCode");

                            b1.HasKey("ServiceProviderPlanId");

                            b1.ToTable("ServiceProviderPlan", "Doss");

                            b1.WithOwner()
                                .HasForeignKey("ServiceProviderPlanId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("ServiceProvider");
                });

            modelBuilder.Entity("Doss.Core.Domain.Vehicles.Vehicle", b =>
                {
                    b.HasOne("Doss.Core.Domain.Residentials.Residential", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ResidentialId");

                    b.HasOne("Doss.Core.Domain.ServiceProviders.ServiceProvider", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ServiceProviderId");
                });

            modelBuilder.Entity("Doss.Core.Domain.OnBoard.OnBoardServiceProvider", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.Residential", b =>
                {
                    b.Navigation("ResidentialWithServiceProviders");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Doss.Core.Domain.Residentials.ResidentialVerificationRequest", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Doss.Core.Domain.ServiceProviders.ServiceProvider", b =>
                {
                    b.Navigation("ServiceProviderPlans");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Doss.Core.Domain.ServiceProviders.ServiceProviderPlan", b =>
                {
                    b.Navigation("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
