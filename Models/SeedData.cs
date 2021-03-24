using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class SeedData
    {
        // Function to check if the database is populated / needs migrations applied
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            // Get context
            MovieDBContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MovieDBContext>();


            // Check if migrations need to be applied
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            
        }
    }
}
