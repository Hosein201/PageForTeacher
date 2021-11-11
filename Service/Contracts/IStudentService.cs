using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<PaymentDto>> GetPayments(int userId, int skip, int take, CancellationToken cancellationToken);
        Task<IEnumerable<StudentDto>> GetStudents(int skip, int take, CancellationToken cancellationToken);
    }
}
