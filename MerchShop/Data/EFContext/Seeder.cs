using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.EFContext
{
    public static class Seeder
    {
        public static void SeedData (UserManager<DbUser> userManager,RoleManager<DbRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<DbUser> userManager)
        {
            if (userManager.FindByNameAsync("TestUser1").Result == null)
            {
                DbUser user = new DbUser();
                user.UserName = "testuser1";
                user.Email = "testuser1@gmail.com";
                IdentityResult result = userManager.CreateAsync(user, "Qwerty-1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            if (userManager.FindByNameAsync("TestUser2").Result == null)
            {
                DbUser user = new DbUser();
                user.UserName = "testuser2";
                user.Email = "testuser2@gmail.com";
                IdentityResult result = userManager.CreateAsync(user, "Qwerty-1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            if (userManager.FindByNameAsync("TestUser3").Result == null)
            {
                DbUser user = new DbUser();
                user.UserName = "testuser3";
                user.Email = "testuser3@gmail.com";
                IdentityResult result = userManager.CreateAsync(user, "Qwerty-1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            if (userManager.FindByNameAsync("TestAdmin").Result == null)
            {
                DbUser user = new DbUser();
                user.UserName = "testadmin";
                user.Email = "testadmin@gmail.com";
                IdentityResult result = userManager.CreateAsync(user, "Qwerty-1").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Administrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<DbRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                DbRole role = new DbRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                DbRole role = new DbRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}

