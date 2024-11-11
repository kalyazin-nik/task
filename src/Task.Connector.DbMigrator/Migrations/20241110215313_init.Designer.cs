﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Task.Connector.DbMigrator;

#nullable disable

namespace Task.Connector.DbMigrator.Migrations
{
    [DbContext(typeof(MigrationDbContext))]
    [Migration("20241110215313_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Task.Connector.Domain.ItRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CorporatePhoneNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar")
                        .HasColumnName("corporate_phone_number");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("it_role", "task");
                });

            modelBuilder.Entity("Task.Connector.Domain.RequestRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("request_right", "task");
                });

            modelBuilder.Entity("Task.Connector.Domain.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("passwords", "task");
                });

            modelBuilder.Entity("Task.Connector.Domain.User", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(22)
                        .HasColumnType("varchar")
                        .HasColumnName("login");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsLead")
                        .HasColumnType("boolean")
                        .HasColumnName("is_lead");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("last_name");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("middle_name");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("telephone_number");

                    b.HasKey("Login");

                    b.HasIndex("Login");

                    b.ToTable("users", "task");
                });

            modelBuilder.Entity("Task.Connector.Domain.UserItRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar")
                        .HasColumnName("user_id");

                    b.HasKey("RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("user_it_role", "task");
                });

            modelBuilder.Entity("Task.Connector.Domain.UserRequestRight", b =>
                {
                    b.Property<int>("RightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("right_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RightId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("varchar")
                        .HasColumnName("user_id");

                    b.HasKey("RightId");

                    b.HasIndex("RightId");

                    b.HasIndex("UserId");

                    b.ToTable("user_request_right", "task");
                });
#pragma warning restore 612, 618
        }
    }
}