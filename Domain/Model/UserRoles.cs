using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class UserRoles : IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
