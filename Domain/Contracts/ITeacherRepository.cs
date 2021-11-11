using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Domain.Contracts
{
    public interface ITeacherRepository:IRepository<Teacher>
    {
        Task CreateTeacher(Teacher teacher, CancellationToken cancellationToken);
        Task<IEnumerable<TeacherDto>> GetTeachers(int skip, int take, CancellationToken cancellationToken);
        Task<TeacherDto> GetTeacher(int userId, CancellationToken cancellationToken);
        Task<IEnumerable<TeachersDto>> GetTeachersByField(int codeField, CancellationToken cancellationToken);
    }
}
