using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Support
    {
        public Support()
        {
            IsReadAdmin = false;
            Answer = string.Empty;
            RegisterDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Message { get; set; }
        public bool IsReadAdmin { get; set; }
        public string Answer { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
