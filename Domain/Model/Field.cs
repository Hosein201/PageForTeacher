using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Field
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public ICollection<UserField> UserFields { get; set; }
        public ICollection<Edu> Edus { get; set; }
    }
}
