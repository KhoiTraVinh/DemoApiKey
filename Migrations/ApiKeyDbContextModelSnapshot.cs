﻿// <auto-generated />
using ApiKey.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiKey.Migrations
{
    [DbContext(typeof(ApiKeyDbContext))]
    partial class ApiKeyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApiKey.Models.ApiKeyModel", b =>
                {
                    b.Property<string>("KeyId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("KeyId");

                    b.ToTable("ApiKey");
                });
#pragma warning restore 612, 618
        }
    }
}
