﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Database.Migrations
{
    [DbContext(typeof(RendyContext))]
    [Migration("20211208202644_Version9.1")]
    partial class Version91
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Database.AutoRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("AutoRoles");
                });

            modelBuilder.Entity("Database.Ban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("ModId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Reason")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("Database.ModSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("InviteBlocker")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Punishment")
                        .HasColumnType("int");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("ModSettings");
                });

            modelBuilder.Entity("Database.Mute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("ModId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Reason")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Mutes");
                });

            modelBuilder.Entity("Database.MuteWhitelist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("ChannelId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("MuteWhilelists");
                });

            modelBuilder.Entity("Database.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ServerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("Database.RestoreRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MuteId")
                        .HasColumnType("int");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("RestoreRoles");
                });

            modelBuilder.Entity("Database.Server", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("AuditLogs")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Background")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("ModLogs")
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("MuteId")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("Welcome")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });
#pragma warning restore 612, 618
        }
    }
}
