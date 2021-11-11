using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class UserField
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
    }
}
