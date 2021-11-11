using System;

namespace Utility.Dto
{
    public class TeacherDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserId { get; set; }
        public int TeachingExperience { get; set; }
        public int Age { get; set; }
        public int EducationalBackground { get; set; }
        public string FieldName { get; set; }
        public string PathImg { get; set; }
    }

    public class TeachersDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
