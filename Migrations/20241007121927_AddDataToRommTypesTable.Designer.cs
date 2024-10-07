﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaNET_JuanJoseZapata.Data;

#nullable disable

namespace PruebaNET_JuanJoseZapata.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241007121927_AddDataToRommTypesTable")]
    partial class AddDataToRommTypesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PruebaNET_JuanJoseZapata.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Availability")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("availability");

                    b.Property<int>("MaxOccupancyPersons")
                        .HasColumnType("int")
                        .HasColumnName("max_occupancy_persons");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("double")
                        .HasColumnName("price_per_night");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("room_number");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("PruebaNET_JuanJoseZapata.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("room_types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A cozy basic room with a single bed, ideal for single travelers.",
                            Name = "single room"
                        },
                        new
                        {
                            Id = 2,
                            Description = "It offers flexibility with two single beds or a double bed, perfect for couples or friends.",
                            Name = "Double Room"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Spacious and luxurious, with a king size bed and a separate living room, ideal for those seeking comfort and exclusivity.",
                            Name = "Suite"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Designed for families, with additional space and several beds for a comfortable stay.",
                            Name = "Family Room"
                        });
                });

            modelBuilder.Entity("PruebaNET_JuanJoseZapata.Models.Room", b =>
                {
                    b.HasOne("PruebaNET_JuanJoseZapata.Models.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });
#pragma warning restore 612, 618
        }
    }
}
