using Forum.Api.Auth.Conficuration;
using Forum.Api.Configuration.Abstractions;
using Forum.Api.Configuration.Seeding;
using Forum.Api.Data;
using Forum.Api.Data.Abstactions;
using Forum.Api.Data.Entities;
using Forum.Api.Data.Repositories;
using Forum.Api.Mapper;
using Forum.Api.Services.Abstractions;
using Forum.Api.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Forum.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["connectionStrings:Default"];
            services.AddTransient<IArticlesService, ArticlesService>();
            services.AddTransient<IArticlesRepository, ArticlesRepository>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<ICommentsRepository, CommentsRepository>();
            services.AddTransient<IDbContextSeedData, DbContextSeedData>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            services.AddDbContext<ForumContext>(options => {
                options.UseSqlServer(connectionString);
            });

            services.AddCors();
            services.AddControllers();
            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ForumContext>();

            var jwtSection = Configuration.GetSection("JwtBearerTokenSettings");
            services.Configure<JwtBearerTokenSettings>(jwtSection);
            var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidIssuer = jwtBearerTokenSettings.Issuer,
                   ValidAudience = jwtBearerTokenSettings.Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
               };
           });


            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Forum.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbContextSeedData seeder)
        {
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forum.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var seed = seeder.CreateAdmin();
            seed.Wait();
        }
    }
}
