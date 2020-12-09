﻿// <auto-generated />
using System;
using Hackaton_test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hackaton_test.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201209122118_UserFix")]
    partial class UserFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Hackaton_test.Models.Achievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AchievementId");

                    b.ToTable("Achievement");
                });

            modelBuilder.Entity("Hackaton_test.Models.EventFollower", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "FollowerId");

                    b.HasIndex("FollowerId");

                    b.ToTable("EventFollower");
                });

            modelBuilder.Entity("Hackaton_test.Models.Poster", b =>
                {
                    b.Property<int>("PosterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SportType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PosterId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Poster");
                });

            modelBuilder.Entity("Hackaton_test.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("UserId");

                    b.HasAlternateKey("NickName");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hackaton_test.Models.UserAchievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AchievementId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAchievement");
                });

            modelBuilder.Entity("Hackaton_test.Models.UserFriend", b =>
                {
                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FriendId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFriend");
                });

            modelBuilder.Entity("Hackaton_test.Models.EventFollower", b =>
                {
                    b.HasOne("Hackaton_test.Models.Poster", "Event")
                        .WithMany("EventFollowers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Hackaton_test.Models.User", "Follower")
                        .WithMany("EventFollowers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("Hackaton_test.Models.Poster", b =>
                {
                    b.HasOne("Hackaton_test.Models.User", "Author")
                        .WithMany("Posters")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Hackaton_test.Models.UserAchievement", b =>
                {
                    b.HasOne("Hackaton_test.Models.Achievement", "Achievement")
                        .WithMany("UserAchievements")
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hackaton_test.Models.User", "User")
                        .WithMany("UserAchievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hackaton_test.Models.UserFriend", b =>
                {
                    b.HasOne("Hackaton_test.Models.User", "Friend")
                        .WithMany("UserFriends")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Hackaton_test.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hackaton_test.Models.Achievement", b =>
                {
                    b.Navigation("UserAchievements");
                });

            modelBuilder.Entity("Hackaton_test.Models.Poster", b =>
                {
                    b.Navigation("EventFollowers");
                });

            modelBuilder.Entity("Hackaton_test.Models.User", b =>
                {
                    b.Navigation("EventFollowers");

                    b.Navigation("Posters");

                    b.Navigation("UserAchievements");

                    b.Navigation("UserFriends");
                });
#pragma warning restore 612, 618
        }
    }
}
