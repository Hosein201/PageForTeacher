using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;

namespace Service.Contracts
{
    public interface IUserService
    {
        Task<AccessToken> Login(UserLoginDto userLogin, CancellationToken cancellationToken = default);
        Task<AccessToken> Regsiter(UserRegsiterDto regsiterDto, CancellationToken cancellationToken = default);
        Task<UserDto> GetCurrentUser(string userName ,string role);
    }
}
