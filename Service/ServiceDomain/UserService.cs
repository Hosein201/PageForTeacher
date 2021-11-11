using AutoMapper;
using Domain.Contracts;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Service.UserManagerExtension;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Utility.Dto;
using Utility.Utilities;

namespace Service.ServiceDomain
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager,
            SignInManager<User> signInManager, IJwtService jwtService, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._jwtService = jwtService;
            this._mapper = mapper;
        }

        public async Task<AccessToken> Login(UserLoginDto userLogin, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByNameAsync(userLogin.UserName);
            if (user != null)
            {
                var checkPassword = await _signInManager.UserManager.CheckPasswordAsync(user, userLogin.PassWord);
                if (checkPassword)
                {

                    List<string> role = (List<string>)await _signInManager.UserManager.GetRolesAsync(user);
                    var token = await _jwtService.GenerateAsync(user, role.FirstOrDefault()?.Trim());
                    return token;
                }
                throw new AppException(ApiResultStatusCode.CheckPassword, "نام کاربری یا رمز عبور اشتباه است");

            }
            throw new AppException(ApiResultStatusCode.NotFoundUser, "کاربر مورد نظر یافت نشد");
        }

        public async Task<AccessToken> Regsiter(UserRegsiterDto regsiterDto, CancellationToken cancellationToken = default)
        {
            var findUserName = await _userManager.FindByNameAsync(regsiterDto.UserName);
            if (findUserName != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, ApiResultStatusCode.UserIsInsystem.ToDisplay());

            var findEmail = await _userManager.FindByEmailAsync(regsiterDto.Email);
            if (findEmail != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "ایمیل در سیستم ثبت شده است");

            var findMobile = await _userManager.FindUserByUserNameAndMobie(regsiterDto.UserName, regsiterDto.PhoneNumber, cancellationToken);
            if (findMobile != null)
                throw new AppException(ApiResultStatusCode.UserIsInsystem, "موبایل در سیستم ثبت شده است");

            var user = _mapper.Map<User>(regsiterDto);

            var userForToken = await _userManager.CreateAsync(user, regsiterDto.PassWord);

            if (!userForToken.Succeeded)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت نام کاربر رخ داده است");

            var roleForToken = await _userManager.AddToRoleAsync(user, Roles.Staudent.ToDisplay());
            if (!roleForToken.Succeeded)
                throw new AppException(ApiResultStatusCode.ServerError, "خطا در ثبت پرمیشن کاربر رخ داده است");

            await _unitOfWork.StudentRepository.CreateStudent(user.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var token = await _jwtService.GenerateAsync(user, Roles.Staudent.ToDisplay());

            return token;
        }

        public async Task<UserDto> GetCurrentUser(string userName, string role)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = _mapper.Map<UserDto>(user);
            result.Role = role;
            return result;
        }
    }
}