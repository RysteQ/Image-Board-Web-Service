﻿// <auto-generated />
using System;
using Image_Board_Web_Service.Services.DBController;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Image_Board_Web_Service.Migrations
{
    [DbContext(typeof(LocalDatabaseController))]
    partial class LocalDatabaseControllerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("Image_Board_Web_Service.Models.OrmModels.CommentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ImageModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Image_Board_Web_Service.Models.OrmModels.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Image_Board_Web_Service.Models.OrmModels.RatingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ImageModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ImageModelId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Image_Board_Web_Service.Models.OrmModels.CommentModel", b =>
                {
                    b.HasOne("Image_Board_Web_Service.Models.OrmModels.ImageModel", "ImageModel")
                        .WithMany("Comments")
                        .HasForeignKey("ImageModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("Image_Board_Web_Service.Models.OrmModels.RatingModel", b =>
                {
                    b.HasOne("Image_Board_Web_Service.Models.OrmModels.ImageModel", "ImageModel")
                        .WithMany("Ratings")
                        .HasForeignKey("ImageModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImageModel");
                });

            modelBuilder.Entity("Image_Board_Web_Service.Models.OrmModels.ImageModel", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}