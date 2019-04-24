using System;
using System.Collections.Generic;
using System.Text;
using MeetMe.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MeetMe.Data
{
    public class MeetMeDbContext : IdentityDbContext<User>
    {
       

        public MeetMeDbContext(DbContextOptions<MeetMeDbContext> options)
        : base(options)
        {
            
        }
        // DBSets      
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Picture> Picture { get; set; }
        public DbSet<ProfilePicture> ProfilePicture { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Friends> Friends { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*Primary Keys*/
            base.OnModelCreating(builder);
            builder.Entity<Friends>().HasKey(k => new { k.UserId, k.ContactId });
            builder.Entity<Messages>().HasAlternateKey(k=> new {k.SenderId,k.RecievedId });
            builder.Entity<User>().HasAlternateKey(k => k.Id);
            builder.Entity<Picture>().HasAlternateKey(k => k.PictureId);
            builder.Entity<ProfilePicture>().HasAlternateKey(k => k.Id);
            builder.Entity<Comment>().HasAlternateKey(k => k.Id);
            builder.Entity<Notification>().HasAlternateKey(k => k.NotificationId);
            
            //Relations beetwin Picture and Cooments
            builder.Entity<Picture>().HasMany(c => c.Comments).WithOne(p => p.Picture).HasForeignKey(fk => fk.Id);
            builder.Entity<Comment>().HasOne(p => p.Picture).WithMany(c => c.Comments).HasForeignKey(fk => fk.PictureId);


            //Relations beetwin Picture and User
            builder.Entity<User>().HasMany(p => p.Pictures).WithOne(u => u.User).HasForeignKey(fk => fk.PictureId);
            builder.Entity<Picture>().HasOne(u => u.User).WithMany(p => p.Pictures).HasForeignKey(fk => fk.UserId);

            //Relations beetwin ProfilePicture and User
            builder.Entity<User>().HasOne<ProfilePicture>(p => p.ProfilePicture).WithOne(u => u.User).HasForeignKey<ProfilePicture>(fk => fk.UserId);
            builder.Entity<ProfilePicture>().HasOne(u => u.User).WithOne(p => p.ProfilePicture).HasForeignKey<User>(fk => fk.ProfilePictureId);

            

            //Relation beetwin User and Friends
            builder.Entity<User>().HasMany(f => f.Friends).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.Entity<User>().HasMany(f => f.Contacts).WithOne(u => u.Contact).HasForeignKey(u => u.ContactId);
            builder.Entity<Friends>().HasOne(u => u.User).WithMany(fr => fr.Friends).HasForeignKey(fk => fk.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Friends>().HasOne(u => u.Contact).WithMany(fr => fr.Contacts).HasForeignKey(fk => fk.ContactId).OnDelete(DeleteBehavior.Restrict);
           

            //Relation beetwin Notification and User & Comment
            builder.Entity<Notification>().HasOne(u => u.User).WithMany(n => n.Notification).HasForeignKey(fk => fk.UserId);
            builder.Entity<User>().HasMany(n => n.Notification).WithOne(u => u.User).HasForeignKey(fk => fk.UserId);
            builder.Entity<Notification>().HasOne(c => c.Comment).WithOne(n => n.Notification).HasForeignKey<Comment>(fk => fk.Id);
            builder.Entity<Comment>().HasOne(c => c.Notification).WithOne(n => n.Comment).HasForeignKey<Notification>(fk => fk.CommentId).OnDelete(DeleteBehavior.Restrict);

            //Implementation Message and User
            builder.Entity<Messages>().HasOne(ru => ru.Received).WithMany(r => r.Received).HasForeignKey(fk =>  fk.RecievedId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>().HasMany(r => r.Received).WithOne(ru => ru.Received).HasForeignKey(fk => fk.RecievedId);
            builder.Entity<Messages>().HasOne(s => s.Sender).WithMany(sd => sd.Send).HasForeignKey(fk => fk.SenderId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>().HasMany(sd => sd.Send).WithOne(s => s.Sender).HasForeignKey(fk => fk.SenderId);

          base.OnModelCreating(builder);

            
        }
    }
}
