using Forum.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Api.Data
{
    public class ForumContext : IdentityDbContext<User>
    {
        public ForumContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog = Forum; Integrated Security = true");
        //}

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticlesCategories> ArticlesCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<CuisineNationality> CuisineNationalities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CuisineNationality>().HasData(new CuisineNationality
            {
                Id = 1,
                Nationality = "Индонезийская кухня"
            },
            new CuisineNationality
            {
                Id = 2,
                Nationality = "Мексиканская кухня"
            },
            new CuisineNationality
            {
                Id = 3,
                Nationality = "Китайская кухня"
            },
            new CuisineNationality
            {
                Id = 4,
                Nationality = "Итальянская кухня"
            },
            new CuisineNationality
            {
                Id = 5,
                Nationality = "Испанская кухня"
            },
            new CuisineNationality
            {
                Id = 6,
                Nationality = "Французкая кухня"
            },
            new CuisineNationality
            {
                Id = 7,
                Nationality = "Японская кухня"
            },
            new CuisineNationality
            {
                Id = 8,
                Nationality = "Индийская кухня"
            },
            new CuisineNationality
            {
                Id = 9,
                Nationality = "Украинская кухня"
            },
            new CuisineNationality
            {
                Id = 10,
                Nationality = "Русская кухня"
            }
            );

            builder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Title = "Любая категория",
            },
            new Category
            {
                Id = 2,
                Title = "Выпечка и десерты",
            },
            new Category
            {
                Id = 3,
                Title = "Основные блюда",
            },
            new Category
            {
                Id = 4,
                Title = "Завтраки",
            },
            new Category
            {
                Id = 5,
                Title = "Салаты",
            },
            new Category
            {
                Id = 6,
                Title = "Супы",
            },
             new Category
             {
                 Id = 7,
                 Title = "Паста и пицца",
             },
            new Category
            {
                Id = 8,
                Title = "Закуски",
            },
            new Category
            {
                Id = 9,
                Title = "Сэндвичи",
            },
            new Category
            {
                Id = 10,
                Title = "Напитки",
            },
            new Category
            {
                Id = 11,
                Title = "Соусы и маринады",
            }
            );

            var admin = new IdentityRole("Admin");
            admin.NormalizedName = admin.Name.ToUpper();
            var manager = new IdentityRole("Manager");
            manager.NormalizedName = manager.Name.ToUpper();
            var user = new IdentityRole("User");
            user.NormalizedName = user.Name.ToUpper();
            builder.Entity<IdentityRole>().HasData(
                admin, manager, user);
        }
    }
}
