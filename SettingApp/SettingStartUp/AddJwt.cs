using Domain.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Utilities;

namespace SettingApp
{
    public static class AddJwt
    {
        public static void AddJwtAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddCookie(options => options.SlidingExpiration = true)
            .AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(jwtSettings.Encryptkey);
                var tokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                };
                options.TokenValidationParameters = tokenValidationParameters;
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        //ToDo
                        //var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                        //logger.LogError("Authentication failed.", context.Exception);

                        if (context.Exception != null)
                            throw new AppException(ApiResultStatusCode.UnAuthorized, "Authentication failed.", HttpStatusCode.Unauthorized, context.Exception, null);

                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        //ToDo
                        //var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                        //logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);

                        if (context.AuthenticateFailure != null)
                            throw new AppException(ApiResultStatusCode.UnAuthorized, "Authenticate failure.", HttpStatusCode.Unauthorized, context.AuthenticateFailure, null);
                        throw new AppException(ApiResultStatusCode.UnAuthorized, "You are unauthorized to access this resource.", HttpStatusCode.Unauthorized);

                      //  return Task.CompletedTask;
                    },
                    OnTokenValidated = async context =>
                    {

                        var signInManager = context.HttpContext.RequestServices.GetRequiredService<SignInManager<User>>();

                        //var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                        //if (claimsIdentity.Claims?.Any() != true) // nullable
                        //    context.Fail("This token has no claims.");

                        //ToDo SecurityStamp in addjwt
                        //var securityStamp = claimsIdentity.FindFirst(new ClaimsIdentityOptions().SecurityStampClaimType); //SecurityStamp

                        // var isActive = bool.Parse(claimsIdentity.FindFirst("IsActive").ToString()); // usr is IsActive
                        // if (!securityStamp.Value.HasValue())
                        // context.Fail("This token has no secuirty stamp");

                        var validatedUser = await signInManager.ValidateSecurityStampAsync(context.Principal);
                        if (validatedUser == null)
                            context.Fail("Token secuirty stamp is not valid.");

                        //if (!isActive)
                        //  context.Fail("User is not active.");

                        //TODo UpdateLastLoginDateAsync in addjwt
                        //await userRepository.UpdateLastLoginDateAsync(user, context.HttpContext.RequestAborted);
                    },

                };
            });
        }
    }
}
