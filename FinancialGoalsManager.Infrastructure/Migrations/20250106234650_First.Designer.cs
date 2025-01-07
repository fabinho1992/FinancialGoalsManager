﻿// <auto-generated />
using System;
using FinancialGoalsManager.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialGoalsManager.Infrastructure.Migrations
{
    [DbContext(typeof(DbFinancialGoalsContext))]
    [Migration("20250106234650_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinancialGoalsManager.Domain.Models.FinancialGoal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<double>("GoalAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<double>("IdealMonthlySaving")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Financial_Goal", (string)null);
                });

            modelBuilder.Entity("FinancialGoalsManager.Domain.Models.FinancialGoalTransactions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasPrecision(10, 2)
                        .HasColumnType("float(10)");

                    b.Property<Guid>("FinancialGoalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FinancialGoalId");

                    b.ToTable("Financial_Transactions", (string)null);
                });

            modelBuilder.Entity("FinancialGoalsManager.Domain.Models.FinancialGoalTransactions", b =>
                {
                    b.HasOne("FinancialGoalsManager.Domain.Models.FinancialGoal", "FinancialGoal")
                        .WithMany("FinancialGoalTransactions")
                        .HasForeignKey("FinancialGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinancialGoal");
                });

            modelBuilder.Entity("FinancialGoalsManager.Domain.Models.FinancialGoal", b =>
                {
                    b.Navigation("FinancialGoalTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
