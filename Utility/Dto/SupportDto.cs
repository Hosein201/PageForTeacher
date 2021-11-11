using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Dto
{
    public class SupportDto
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Message { get; set; }
        public bool IsReadAdmin { get; set; }
        public string Answer { get; set; }
        public DateTime RegisterDate { get; set; }
    }

    public class SupportCreateDto
    {
         public string Titel { get; set; }
        public string Message { get; set; }
    }

    public class UpdateSupportDto
    {
        public UpdateSupportDto()
        {
            IsReadAdmin = true;
        }
        public bool IsReadAdmin { get; set; }
        public string Answer { get; set; }
        public int Id { get; set; }
    }
}
