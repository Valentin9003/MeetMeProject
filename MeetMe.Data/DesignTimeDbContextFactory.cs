using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetMe.Data
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MeetMeDbContext>
    {
        public MeetMeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MeetMeDbContext>();
            builder.UseSqlServer("Server=LAPTOP-FOQETJAV\\SQLEXPRESS;Database=MeetMe;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context = new MeetMeDbContext(builder.Options);
            return context;
        }
    }
}
