using Forum.Api.Auth.Models;
using Forum.Api.Configuration.Abstractions;
using Forum.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Configuration.Seeding
{
    public class DbContextSeedData : IDbContextSeedData
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbContextSeedData(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateAdmin()
        {
            var roleName = RolesEnum.Admin.GetEnumDescription();
            var roleFromDb = await _roleManager.FindByNameAsync(roleName);

            if (roleFromDb != null)
            {
                var admin = new User(){UserName = "admin", NormalizedUserName = "ADMIN", Email = "admin@culinaryforum.com", NormalizedEmail = "ADMIN@CULINARYFORUM.COM"};

                var password = "adminPass1+1";

                var checkingInBd = await _userManager.FindByNameAsync(admin.UserName);
                if (checkingInBd == null)
                {
                    await _userManager.CreateAsync(admin, password);
                    await _userManager.AddToRoleAsync(admin, roleName);
                }
            }
        }
    }
}
