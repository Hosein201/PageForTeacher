using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Model
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            this.IsActive = true;
            this.IsLock = false;
        }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string NationalCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public string BirthDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsLock { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<Support> Supports { get; set; }
        public ICollection<PathImg> PathImgs { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<UserField> UserFields { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
    }
}
