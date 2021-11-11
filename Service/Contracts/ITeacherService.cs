using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.Contracts
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetTeachers(int skip, int take, CancellationToken cancellationToken);
        Task<TeacherDto> GetTeacher(int userId, CancellationToken cancellationToken);
        Task<IEnumerable<TeachersDto>> GetTeachersByField(int codeField, CancellationToken cancellationToken);
    }
}
