using Domain;
using Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Utility.Interfac;
using Utility.Utilities;

namespace SettingApp
{
    public static class ApplicationBuilder
    {
        public static void UseHsts(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            Assert.NotNull(app, nameof(app));
            Assert.NotNull(env, nameof(env));

            if (!env.IsDevelopment())
                app.UseHsts();
        }

        public static void IntializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<TeacherDbContext>(); //Service locator
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
                //Dos not use Migrations, just Create Database with latest changes
                //dbContext.Database.EnsureCreated();
                //Applies any pending migrations for the context to the database like (Update-Database)
                dbContext.Database.Migrate();
                SeedDate(dbContext , userManager).Wait();

                //var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
                //foreach (var dataInitializer in dataInitializers)
                //    dataInitializer.InitializeData();
            }
        }

        private static async Task SeedDate(TeacherDbContext teacherDbContext , UserManager<User> _userManager)
        {
            bool IsChangeDb = false;

            var anyRole= await teacherDbContext.Roles.AnyAsync();
            if (!anyRole)
            {
              await  teacherDbContext.Roles.AddRangeAsync(
                   new Role 
                   { 
                       Name=Roles.Admin.ToDisplay(),
                       ConcurrencyStamp=Guid.NewGuid().ToString(),
                       Description= Roles.Admin.ToDisplay(),
                       NormalizedName= Roles.Admin.ToDisplay().ToUpper(),
                       CodeRole=1
                   },
                   new Role 
                   {
                       Name = Roles.Staudent.ToDisplay(),
                       ConcurrencyStamp = Guid.NewGuid().ToString(),
                       Description = Roles.Staudent.ToDisplay(),
                       NormalizedName = Roles.Staudent.ToDisplay().ToUpper(),
                       CodeRole = 2
                   },
                   new Role
                   {
                       Name = Roles.Teacher.ToDisplay(),
                       ConcurrencyStamp = Guid.NewGuid().ToString(),
                       Description = Roles.Teacher.ToDisplay(),
                       NormalizedName = Roles.Teacher.ToDisplay().ToUpper(),
                       CodeRole = 3
                   },
                   new Role
                   {
                       Name = Roles.Support.ToDisplay(),
                       ConcurrencyStamp = Guid.NewGuid().ToString(),
                       Description = Roles.Support.ToDisplay(),
                       NormalizedName = Roles.Support.ToDisplay().ToUpper(),
                       CodeRole = 4
                   });
                IsChangeDb = true;
            }

            var anyAdmin = await _userManager.FindByNameAsync("agent1");
            if (anyAdmin is null)
            {
                var user = new User
                {
                    UserName = "agent1",
                    Address = "تهران",
                    BirthDate = string.Empty,
                    Email = "Hoseingolmohammadi193@yahoo.com",
                    EmailConfirmed = true,
                    FName = "حسین",
                    IsActive = true,
                    IsLock = false,
                    LName = "گل محمدی",
                    NationalCode = "1234567891",
                    NormalizedEmail = "Hoseingolmohammadi193@yahoo.com".ToUpper(),
                    PhoneNumber = "09226323605",
                    PhoneNumberConfirmed = true,
                    RegisterDate = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    NormalizedUserName = "agent1".ToUpper()
                };
              //  user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, "Hossein193")

               await _userManager.CreateAsync(user , "Hossein193");
               await _userManager.AddToRoleAsync(user, Roles.Admin.ToDisplay());
            }

            if (IsChangeDb)
                await teacherDbContext.SaveChangesAsync();
        }
    }
}
