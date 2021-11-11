using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class PathImg
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public int TypeImg { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
    }
}
