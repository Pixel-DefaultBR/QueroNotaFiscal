﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QueroNotaFiscal.Database;

#nullable disable

namespace QueroNotaFiscal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250531010151_OrtographyCorrection2")]
    partial class OrtographyCorrection2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("QueroNotaFiscal.Models.FiscalNoteEntity", b =>
                {
                    b.Property<int>("FiscalNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FiscalNoteId"));

                    b.Property<string>("CNPJIssuing")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CNPJRecipent")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("FiscalNoteNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FiscalNoteId");

                    b.ToTable("FiscalNotes");
                });
#pragma warning restore 612, 618
        }
    }
}
