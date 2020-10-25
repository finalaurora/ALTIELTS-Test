using ALTIELTS_RatingSite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ALTIELTS_RatingSite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            RatingsContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RatingsContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            
            if (context.Departments.Any())
            {
                return;
            }

            var departments = new Department[]
            {
                new Department{Name = "Bảo vệ", PassCode="1111"},
                new Department{Name = "CSKH", PassCode="2222"},
                new Department{Name = "Lao công", PassCode="3333"}
            };

            foreach (Department dept in departments)
            {
                context.Departments.Add(dept);
            }
            context.SaveChanges();

            var ratings = new Rating[]
            {
                new Rating{DeptId=1,QuestionNo=1, Point=4, Comment="Cần cải thiện nhiều hơn", DateTime = DateTime.Now},
                new Rating{DeptId=2,QuestionNo=2, Point=5, Comment="No comment", DateTime = DateTime.Now},
                new Rating{DeptId=3,QuestionNo=3, Point=3, Comment="Hơi kém", DateTime = DateTime.Now},
            };

            foreach (Rating rating in ratings)
            {
                context.Ratings.Add(rating);
            }
            context.SaveChanges();
        }
    }
}
