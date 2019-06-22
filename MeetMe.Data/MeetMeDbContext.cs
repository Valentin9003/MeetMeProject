using System;
using System.Collections.Generic;
using System.Text;
using MeetMe.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Identity;

namespace MeetMe.Data
{
    public class MeetMeDbContext : IdentityDbContext<User>
    {
       

        public MeetMeDbContext(DbContextOptions<MeetMeDbContext> options)
        : base(options)
        {
            
        }
        // DBSets      
    
        public DbSet<User> User { get; set; }
        public DbSet<Picture> Picture { get; set; }
       
       
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Friends> Friends { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*Primary Keys*/
            base.OnModelCreating(builder);
            builder.Entity<Friends>().HasKey(k => new { k.UserId, k.ContactId });
            builder.Entity<Messages>().HasKey(k=> new {k.SenderId,k.RecievedId });
            builder.Entity<User>().HasKey(k => k.Id);
            builder.Entity<Picture>().HasKey(k => k.PictureId);
           
           
            
            


            //Relations beetwin Picture and User
            builder.Entity<User>()
                .HasMany(p => p.Pictures)
                .WithOne(u => u.User)
                .HasForeignKey(fk => fk.UserId); 

           //Relation beetwin User and Friends
           
            builder.Entity<Friends>()
                .HasOne(u => u.User)
                .WithMany(fr => fr.Friends)
                .HasForeignKey(fk => fk.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friends>()
                .HasOne(u => u.Contact)
                .WithMany(fr => fr.Contacts)
                .HasForeignKey(fk => fk.ContactId)
                .OnDelete(DeleteBehavior.Restrict);
           

           
            //Implementation Message and User
            builder.Entity<Messages>()
                .HasOne(ru => ru.Received)
                .WithMany(r => r.Received)
                .HasForeignKey(fk =>  fk.RecievedId)
                .OnDelete(DeleteBehavior.Restrict);
         
            builder.Entity<Messages>()
                .HasOne(s => s.Sender)
                .WithMany(sd => sd.Send)
                .HasForeignKey(fk => fk.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
         

             base.OnModelCreating(builder);



            /*Check cascade delete for all entities*/

        }
    }
}
