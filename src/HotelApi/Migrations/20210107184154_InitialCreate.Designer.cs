﻿// <auto-generated />
using System;
using HotelApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelApi.Migrations
{
    [DbContext(typeof(MyHotelDbContext))]
    [Migration("20210107184154_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HotelApi.Entities.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alper Ebicoglu",
                            RegisterDate = new DateTime(2020, 12, 28, 18, 41, 54, 267, DateTimeKind.Local).AddTicks(5384)
                        },
                        new
                        {
                            Id = 2,
                            Name = "George Michael",
                            RegisterDate = new DateTime(2021, 1, 2, 18, 41, 54, 275, DateTimeKind.Local).AddTicks(1541)
                        },
                        new
                        {
                            Id = 3,
                            Name = "Daft Punk",
                            RegisterDate = new DateTime(2021, 1, 6, 18, 41, 54, 275, DateTimeKind.Local).AddTicks(1725)
                        });
                });

            modelBuilder.Entity("HotelApi.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckinDate = new DateTime(2021, 1, 5, 18, 41, 54, 275, DateTimeKind.Local).AddTicks(6303),
                            CheckoutDate = new DateTime(2021, 1, 10, 18, 41, 54, 275, DateTimeKind.Local).AddTicks(6323),
                            GuestId = 1,
                            RoomId = 3
                        },
                        new
                        {
                            Id = 2,
                            CheckinDate = new DateTime(2021, 1, 6, 18, 41, 54, 275, DateTimeKind.Local).AddTicks(9922),
                            CheckoutDate = new DateTime(2021, 1, 11, 18, 41, 54, 275, DateTimeKind.Local).AddTicks(9941),
                            GuestId = 2,
                            RoomId = 4
                        });
                });

            modelBuilder.Entity("HotelApi.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AllowedSmoking")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowedSmoking = false,
                            Name = "yellow-room",
                            Number = 101,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            AllowedSmoking = false,
                            Name = "blue-room",
                            Number = 102,
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            AllowedSmoking = false,
                            Name = "white-room",
                            Number = 103,
                            Status = 0
                        },
                        new
                        {
                            Id = 4,
                            AllowedSmoking = false,
                            Name = "black-room",
                            Number = 104,
                            Status = 0
                        });
                });

            modelBuilder.Entity("HotelApi.Entities.Reservation", b =>
                {
                    b.HasOne("HotelApi.Entities.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelApi.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
