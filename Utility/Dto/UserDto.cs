using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Utility.Dto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید")]
        public string PassWord { get; set; }
    }

    public class UserRegsiterDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "لطفا موبایل خود را وارد کنید")]
        [Phone]
        public string PhoneNumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string NationalCode { get; set; }
        public string BirthDate { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        public string Email { get; set; }
    }

    public class UserDto
    {
        public UserDto()
        {
            this.Role = string.Empty;
        }
        public string PhoneNumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string NationalCode { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
