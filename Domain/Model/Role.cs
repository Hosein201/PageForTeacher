using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Role:IdentityRole<int>
    {
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public int CodeRole { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
