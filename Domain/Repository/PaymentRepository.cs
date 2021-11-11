using Domain.Contracts;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Domain.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(TeacherDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<PaymentDto>> GetPayments(int userId, int skip, int take, CancellationToken cancellationToken)
        {
            return await AsNoTracking().Where(w => w.UserId == userId).Skip(skip).Take(take)
                .Select(s => new PaymentDto
                {
                    UserId = s.UserId,
                    Amount = s.Amount,
                    Dcs = s.Dcs,
                    PaymentId = s.Id,
                    RegisterDate = s.RegisterDate,
                    TypePayment = s.TypePayment
                }).ToListAsync(cancellationToken);
        }
    }
}
