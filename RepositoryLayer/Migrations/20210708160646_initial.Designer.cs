﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(P2Context))]
    [Migration("20210708160646_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelsLayer.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(210)
                        .HasColumnType("nvarchar(210)");

                    b.Property<DateTime>("DateMade")
                        .HasColumnType("datetime");

                    b.Property<string>("MovieId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ModelsLayer.Movie", b =>
                {
                    b.Property<string>("MovieId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ModelsLayer.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Content")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateMade")
                        .HasColumnType("datetime");

                    b.Property<string>("MovieId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("ModelsLayer.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ModelsLayer.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ShowingTime")
                        .HasColumnType("datetime");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("MovieId");

                    b.HasIndex("TheaterId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("ModelsLayer.Theater", b =>
                {
                    b.Property<int>("TheaterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TheaterLoc")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("TheaterName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TheaterId");

                    b.ToTable("Theater");
                });

            modelBuilder.Entity("ModelsLayer.TheaterMovie", b =>
                {
                    b.Property<string>("MovieId")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TheaterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "TheaterId")
                        .HasName("PK__Theater___CF041F3B0F975522");

                    b.HasIndex("TheaterId");

                    b.ToTable("Theater_Movies");
                });

            modelBuilder.Entity("ModelsLayer.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Passwd")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModelsLayer.Comment", b =>
                {
                    b.HasOne("ModelsLayer.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__Comment__MovieId__239E4DCF")
                        .IsRequired();

                    b.HasOne("ModelsLayer.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Comment__UserId__22AA2996")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelsLayer.Rating", b =>
                {
                    b.HasOne("ModelsLayer.Movie", "Movie")
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__Rating__MovieId__1DE57479")
                        .IsRequired();

                    b.HasOne("ModelsLayer.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Rating__UserId__1CF15040")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ModelsLayer.Schedule", b =>
                {
                    b.HasOne("ModelsLayer.Movie", "Movie")
                        .WithMany("Schedules")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__Schedule__MovieI__182C9B23")
                        .IsRequired();

                    b.HasOne("ModelsLayer.Theater", "Theater")
                        .WithMany("Schedules")
                        .HasForeignKey("TheaterId")
                        .HasConstraintName("FK__Schedule__Theate__173876EA")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("ModelsLayer.TheaterMovie", b =>
                {
                    b.HasOne("ModelsLayer.Movie", "Movie")
                        .WithMany("TheaterMovies")
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK__Theater_M__Movie__1273C1CD")
                        .IsRequired();

                    b.HasOne("ModelsLayer.Theater", "Theater")
                        .WithMany("TheaterMovies")
                        .HasForeignKey("TheaterId")
                        .HasConstraintName("FK__Theater_M__Theat__117F9D94")
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Theater");
                });

            modelBuilder.Entity("ModelsLayer.User", b =>
                {
                    b.HasOne("ModelsLayer.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Users__RoleId__0519C6AF")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ModelsLayer.Movie", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");

                    b.Navigation("Schedules");

                    b.Navigation("TheaterMovies");
                });

            modelBuilder.Entity("ModelsLayer.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ModelsLayer.Theater", b =>
                {
                    b.Navigation("Schedules");

                    b.Navigation("TheaterMovies");
                });

            modelBuilder.Entity("ModelsLayer.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
