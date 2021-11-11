using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Student
    {
        public Student()
        {
            RegisterDate = DateTime.Now;
            IsLock = false;
        }
        [Key]
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsLock { get; set; }
        public int CountEdu { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Edu> Edus { get; set; }
    }
}
