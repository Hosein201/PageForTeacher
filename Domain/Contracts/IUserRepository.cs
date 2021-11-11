using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUserRepository :IRepository<User>
    {
        //Task<User> GetUserByName(string UserName, CancellationToken cancellationToken);
        //Task<User> GetUserByMobile(string PhoneNumber, CancellationToken cancellationToken);
    }
}
