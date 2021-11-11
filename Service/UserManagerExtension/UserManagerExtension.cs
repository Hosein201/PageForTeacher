using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Service.UserManagerExtension
{
    public static class UserManagerExtension
    {
        public static async Task<User> GetUserAdmin(this UserManager<User> userManager , CancellationToken cancellationToken)
        {
            var result =await userManager.Users.AsNoTracking().Where(t => t.UserRoles.FirstOrDefault().Role.Name == "Admin")
                .FirstOrDefaultAsync(cancellationToken);
            return result;
        } 
        public static async Task<User> FindUserByUserNameAndMobie(this UserManager<User> userManager ,string userName , string mobile, CancellationToken cancellationToken)
        {
            var result =await userManager.Users.Where(w=> w.UserName==userName && w.PhoneNumber==mobile)
                .FirstOrDefaultAsync(cancellationToken);
            return result;
        } 
        public static async Task<bool> CheckActiveUser(this UserManager<User> userManager ,string userName, CancellationToken cancellationToken=default)
        {
            var result =await userManager.Users.FirstOrDefaultAsync(w=> w.UserName==userName ,cancellationToken);
            return result.IsActive;
        }
        public static async Task<bool> CheckLockUser(this UserManager<User> userManager, string userName, CancellationToken cancellationToken = default)
        {
            var result = await userManager.Users.FirstOrDefaultAsync(w => w.UserName == userName, cancellationToken);
            return result.IsLock;
        }
    }
}
