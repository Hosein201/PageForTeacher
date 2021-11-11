using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Edu
    {
        public Edu()
        {
            RegisterDate = DateTime.Now;
            IsEnd = false;
        }

        [Key]
        public int Id { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public bool IsEnd { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
