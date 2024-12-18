﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoSharingConsole;

#nullable disable

namespace VideoSharingConsole.Migrations
{
    [DbContext(typeof(VideoSharingContext))]
    [Migration("20241127190556_owner")]
    partial class owner
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollaborativeEventCreator", b =>
                {
                    b.Property<int>("CreatorsID")
                        .HasColumnType("int");

                    b.Property<int>("EventsID")
                        .HasColumnType("int");

                    b.HasKey("CreatorsID", "EventsID");

                    b.HasIndex("EventsID");

                    b.ToTable("CollaborativeEventCreator");
                });

            modelBuilder.Entity("VideoSharingPlatform.CollaborativeEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CollaborativeEvent");
                });

            modelBuilder.Entity("VideoSharingPlatform.Creator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Creator");
                });

            modelBuilder.Entity("VideoSharingPlatform.Statistics", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("AverageCommentsPerHour")
                        .HasColumnType("float");

                    b.Property<double>("AveragePercentageWatchtime")
                        .HasColumnType("float");

                    b.Property<double>("AverageViewsPerHour")
                        .HasColumnType("float");

                    b.Property<string>("TargetAudience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("VideoSharingPlatform.Video", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatorID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LengthInSeconds")
                        .HasColumnType("int");

                    b.Property<int>("StatisticsID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CreatorID");

                    b.HasIndex("StatisticsID")
                        .IsUnique();

                    b.ToTable("Video");
                });

            modelBuilder.Entity("CollaborativeEventCreator", b =>
                {
                    b.HasOne("VideoSharingPlatform.Creator", null)
                        .WithMany()
                        .HasForeignKey("CreatorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoSharingPlatform.CollaborativeEvent", null)
                        .WithMany()
                        .HasForeignKey("EventsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VideoSharingPlatform.Video", b =>
                {
                    b.HasOne("VideoSharingPlatform.Creator", "Creator")
                        .WithMany("Videos")
                        .HasForeignKey("CreatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VideoSharingPlatform.Statistics", "Statistics")
                        .WithOne("Video")
                        .HasForeignKey("VideoSharingPlatform.Video", "StatisticsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Statistics");
                });

            modelBuilder.Entity("VideoSharingPlatform.Creator", b =>
                {
                    b.Navigation("Videos");
                });

            modelBuilder.Entity("VideoSharingPlatform.Statistics", b =>
                {
                    b.Navigation("Video")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
