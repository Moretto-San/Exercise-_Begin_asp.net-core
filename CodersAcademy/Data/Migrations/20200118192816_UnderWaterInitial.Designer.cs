﻿// <auto-generated />
using System;
using CodersAcademy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodersAcademy.Data.Migrations
{
    [DbContext(typeof(UnderWaterContext))]
    [Migration("20200118192816_UnderWaterInitial")]
    partial class UnderWaterInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Underwater.Models.Aquarium", b =>
                {
                    b.Property<int>("AquariumId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("Address")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(150);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnName("Number")
                        .HasMaxLength(200);

                    b.Property<bool>("Open")
                        .HasColumnName("Open");

                    b.HasKey("AquariumId");

                    b.ToTable("Aquarium");
                });

            modelBuilder.Entity("Underwater.Models.Fish", b =>
                {
                    b.Property<int>("FishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AquariumId");

                    b.Property<string>("CommonName")
                        .HasMaxLength(300);

                    b.Property<string>("ImageMimeType")
                        .IsRequired();

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("ImageURL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<byte[]>("PhotoAvatar");

                    b.Property<byte[]>("PhotoFile")
                        .HasMaxLength(300);

                    b.Property<string>("ScientificName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("FishId");

                    b.HasIndex("AquariumId");

                    b.ToTable("Fish");
                });

            modelBuilder.Entity("Underwater.Models.Fish", b =>
                {
                    b.HasOne("Underwater.Models.Aquarium", "Aquarium")
                        .WithMany("Fishes")
                        .HasForeignKey("AquariumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}