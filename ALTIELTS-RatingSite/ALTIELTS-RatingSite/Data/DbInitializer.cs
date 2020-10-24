using ALTIELTS_RatingSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ALTIELTS_RatingSite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RatingsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any())
            {
                return;
            }

            var departments = new Department[]
            {
                new Department{ID = 1, Name = "Bảo vệ", PassCode="1111"},
                new Department{ID = 2, Name = "CSKH", PassCode="2222"},
                new Department{ID = 3, Name = "Lao công", PassCode="3333"}
            };

            foreach (Department dept in departments)
            {
                context.Departments.Add(dept);
            }
            context.SaveChanges();

            var ratings = new Rating[]
            {
                new Rating{Id = 1, DeptId=1,QuestionNo=1, Point=4, Comment="Cần cải thiện nhiều hơn", DateTime = DateTime.Now},
                new Rating{Id = 2, DeptId=2,QuestionNo=2, Point=5, Comment="No comment", DateTime = DateTime.Now},
                new Rating{Id = 3, DeptId=3,QuestionNo=3, Point=3, Comment="Hơi kém", DateTime = DateTime.Now},
            };

            foreach (Rating rating in ratings)
            {
                context.Ratings.Add(rating);
            }
            context.SaveChanges();
        }
    }
}
