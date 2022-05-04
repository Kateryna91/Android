using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Constants;
using Shop.Data.Entities.Identity;

namespace Shop.Data
{
    public static class SeederDB
    {
        public static void SeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppEFContext>();
                    context.Database.Migrate();
                    SeedRoleAndUser(services);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private static void SeedRoleAndUser(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            if(!roleManager.Roles.Any())
            {
                var result = roleManager.CreateAsync(new AppRole
                {
                    Name = Roles.Admin
                }).Result;

                result = roleManager.CreateAsync(new AppRole
                {
                    Name = Roles.User
                }).Result;
            }
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    FirstName = "Петро",
                    SecondName = "Мельник",
                    Phone = "+38098839384",
                    Photo = "gwjziscd.q1g.jpeg"
                };
                var result = userManager.CreateAsync(user, "123456").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, Roles.Admin).Result;
                }
            }
        }
    }
}
