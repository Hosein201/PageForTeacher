using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork 
    {
        IUserRepository UserRepository { get; set; }
        ISupportRepository SupportRepository { get; set; }
        IStudentRepository StudentRepository { get; set; }
        ITeacherRepository TeacherRepository { get; set; }
        IFieldRepository FieldRepository { get; set; }
        IPaymentRepository PaymentRepository { get; set; }
        IEduRepository EduRepository { get; set; }

        void SaveChange();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
