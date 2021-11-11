using Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Domain.Contracts
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task CreateStudent(int userId, CancellationToken cancellationToken);
        Task<IEnumerable<StudentDto>> GetStudents(int skip, int take, CancellationToken cancellationToken);
    }
}
