using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetMe.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MeetMe.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeetMe.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtentions
    {

        //Databese Migration
        public static IApplicationBuilder UseDataBaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MeetMeDbContext>().Database.Migrate();

              

            }

            return app;
        }

        
    }
    
}
