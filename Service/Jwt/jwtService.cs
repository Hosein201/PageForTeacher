using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    public class JwtService : IJwtService
    {

        private readonly SignInManager<User> signInManager;

        public JwtService(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<AccessToken> GenerateAsync(User user, string roleName)
        {
            var securityKey = Encoding.UTF8.GetBytes("LongerThan-16Char-SecretKey");
            var encryptkey = Encoding.UTF8.GetBytes("16CharEncryptKey");
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey)
                , SecurityAlgorithms.HmacSha256Signature);

            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptkey),
                SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var Claims = await getClaims(user, roleName);
            var descriptor = new SecurityTokenDescriptor()
            {
                Audience = "Teacher",
                Issuer = "Teacher",
                Expires = DateTime.Now.AddMinutes(60),
                NotBefore = DateTime.Now.AddMinutes(0),
                Subject = new ClaimsIdentity(Claims),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessToken(securityToken);
        }

        private async Task<IEnumerable<Claim>> getClaims(User user, string roleName)
        {
            var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            var listClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(securityStampClaimType, user.SecurityStamp.ToString()),
                new Claim(ClaimTypes.Role,roleName),
                new Claim(ClaimTypes.Surname,  string.IsNullOrEmpty(user.LName)? "پروفایل کاربری" : $"{user.FName} {user.LName}"),
               // new Claim(type:"PathImgUser", value: user.PathImgUser is null ? "placeholderImage.jpg" : user.PathImgUser)
            };
            var result = await signInManager.ClaimsFactory.CreateAsync(user);
            var Claim = result.Claims;
            return listClaim;
        }
    }
}
