﻿// <auto-generated />
using System;
using MeetMe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetMeData.Migrations
{
    [DbContext(typeof(MeetMeDbContext))]
    [Migration("20190420005358_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetMeData.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentValue")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("NotificationId");

                    b.Property<string>("PictureId");

                    b.Property<string>("ProfilePictureId");

                    b.Property<DateTime>("WritingТime");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("ProfilePictureId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MeetMeData.Models.Friends", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("ContactId");

                    b.Property<bool>("IsAccepted");

                    b.HasKey("UserId", "ContactId");

                    b.HasIndex("ContactId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("MeetMeData.Models.Messages", b =>
                {
                    b.Property<string>("MessagesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("RecievedId")
                        .IsRequired();

                    b.Property<string>("SenderId")
                        .IsRequired();

                    b.Property<DateTime>("TimeOfSeen");

                    b.Property<DateTime>("TimeOfSend");

                    b.Property<bool>("UnreadOrRead");

                    b.HasKey("MessagesId");

                    b.HasAlternateKey("SenderId", "RecievedId");

                    b.HasIndex("RecievedId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MeetMeData.Models.Notification", b =>
                {
                    b.Property<string>("NotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentId");

                    b.Property<string>("FromUserId");

                    b.Property<DateTime>("NotificationТime");

                    b.Property<string>("PictureId");

                    b.Property<string>("UserId");

                    b.Property<string>("informationForNotification")
                        .IsRequired();

                    b.HasKey("NotificationId");

                    b.HasIndex("CommentId")
                        .IsUnique()
                        .HasFilter("[CommentId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("MeetMeData.Models.Picture", b =>
                {
                    b.Property<string>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<byte[]>("PictureByteArray")
                        .IsRequired()
                        .HasMaxLength(10485760);

                    b.Property<string>("UserId");

                    b.HasKey("PictureId");

                    b.HasIndex("UserId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("MeetMeData.Models.ProfilePicture", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(100);

                    b.Property<byte[]>("PictureByteArray")
                        .IsRequired()
                        .HasMaxLength(10485760);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ProfilePicture");
                });

            modelBuilder.Entity("MeetMeData.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Biography")
                        .HasMaxLength(500);

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("City")
                        .HasMaxLength(20);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country")
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("EyeColor");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20);

                    b.Property<double>("Height");

                    b.Property<bool>("IsOnline");

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int>("LookingFor");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePictureId");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Sex");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("Weight")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProfilePictureId")
                        .IsUnique()
                        .HasFilter("[ProfilePictureId] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MeetMeData.Models.Comment", b =>
                {
                    b.HasOne("MeetMeData.Models.Picture", "Picture")
                        .WithMany("Comments")
                        .HasForeignKey("PictureId");

                    b.HasOne("MeetMeData.Models.ProfilePicture")
                        .WithMany("Comments")
                        .HasForeignKey("ProfilePictureId");
                });

            modelBuilder.Entity("MeetMeData.Models.Friends", b =>
                {
                    b.HasOne("MeetMeData.Models.User", "Contact")
                        .WithMany("Contacts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeetMeData.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MeetMeData.Models.Messages", b =>
                {
                    b.HasOne("MeetMeData.Models.User", "Received")
                        .WithMany("Received")
                        .HasForeignKey("RecievedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeetMeData.Models.User", "Sender")
                        .WithMany("Send")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MeetMeData.Models.Notification", b =>
                {
                    b.HasOne("MeetMeData.Models.Comment", "Comment")
                        .WithOne("Notification")
                        .HasForeignKey("MeetMeData.Models.Notification", "CommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MeetMeData.Models.User", "User")
                        .WithMany("Notification")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MeetMeData.Models.Picture", b =>
                {
                    b.HasOne("MeetMeData.Models.User", "User")
                        .WithMany("Pictures")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MeetMeData.Models.User", b =>
                {
                    b.HasOne("MeetMeData.Models.ProfilePicture", "ProfilePicture")
                        .WithOne("User")
                        .HasForeignKey("MeetMeData.Models.User", "ProfilePictureId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MeetMeData.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MeetMeData.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeetMeData.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MeetMeData.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}