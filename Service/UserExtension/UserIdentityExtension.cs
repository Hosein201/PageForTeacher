using System;
using System.Security.Claims;
using System.Security.Principal;
using Utility.Utilities;

namespace Service.UserIdentityExtension
{
    public static class UserIdentityExtension
    {
        public static int GetUserId(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return int.Parse(claim.Value);
        } 
     
        public static string GetMobileUser(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.MobilePhone);

            return claim.Value;
        }
     
        public static string GetFullNameUser(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Surname);

            if (!string.IsNullOrEmpty(claim.Value))
                return Convert.ToString(claim.Value);

            return string.Empty;
        }
      
        public static string GetUserName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Name);

            return claim.Value;
        }
      
        public static string GetRoleOfUser(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Role);

            return claim.Value;
        }

        public static bool IsAdmin(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Role);

            if (!string.IsNullOrEmpty(claim.Value) && claim.Value == Roles.Admin.ToDisplay())
                return true;
            return false;
        }

        public static string GetPathImgUser(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;

            Claim claim = claimsIdentity.FindFirst("PathImgUser");

            if (!string.IsNullOrEmpty(claim.Value))
                return Convert.ToString(claim.Value);

            return string.Empty;
        }

        //public static Task<List<T>> GetRoleByUserName<T>(this RoleManager<User> roleManager, Guid Id)
        //{
        //    roleManager.Roles.Include("AspNetUserRoles")?.SingleOrDefaultAsync(s=> s.)
        //    return null;
        //}
    }
}