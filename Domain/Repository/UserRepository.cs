using Domain.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TeacherDbContext dbContext)
            : base(dbContext)
        {
        }


        //public async Task<User> GetUserBy(string UserName, CancellationToken cancellationToken)
        //{

        //    return await GetByIdAsNoTrackingAsync(nameof(UserName), UserName, cancellationToken);
        //}

        //public async Task<User> GetUserById(Guid userId, CancellationToken cancellationToken)
        //{
        //    return await TableNoTracking.FirstOrDefaultAsync(s => s.Id == userId, cancellationToken);

        //}
        //public async Task<User> GetUserByMobile(string PhoneNumber, CancellationToken cancellationToken)
        //{
        //    return await GetByIdAsNoTrackingAsync(nameof(PhoneNumber), PhoneNumber, cancellationToken);
        //}
    }
}
