﻿// <auto-generated />
using System;
using BB.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BB.Web.Data.Migrations
{
    [DbContext(typeof(BlazingContext))]
    [Migration("20241003034041_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BB.Web.Domain.Actuals.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("amount");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("category");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<DateTimeOffset>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.HasKey("Id")
                        .HasName("p_k_transactions");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("BB.Web.Domain.Category", b =>
                {
                    b.Property<string>("Value")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("category");

                    b.Property<string>("parent_category")
                        .HasColumnType("character varying(200)")
                        .HasColumnName("parent_category");

                    b.HasKey("Value")
                        .HasName("pk_category");

                    b.HasIndex("parent_category")
                        .HasDatabaseName("i_x_categories_parent_category");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("BB.Web.Domain.Category", b =>
                {
                    b.HasOne("BB.Web.Domain.Category", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("parent_category")
                        .HasConstraintName("fk_parent_category");
                });

            modelBuilder.Entity("BB.Web.Domain.Category", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}