using Domain.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Domain.Contracts
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<PaymentDto>> GetPayments(int userId, int skip, int take, CancellationToken cancellationToken);
    }
}
