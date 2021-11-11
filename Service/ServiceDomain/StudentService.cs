using Domain.Contracts;
using Service.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.ServiceDomain
{
    public class StudentService : IStudentService
    {
        public IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PaymentDto>> GetPayments(int userId, int skip, int take, CancellationToken cancellationToken)
        {
            return await _unitOfWork.PaymentRepository.GetPayments(userId,skip,take,cancellationToken);
        }

        public async Task<IEnumerable<StudentDto>> GetStudents(int skip, int take, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StudentRepository.GetStudents(skip, take, cancellationToken);
        }
    }
}
