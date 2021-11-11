using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using SettingApp;
using SettingApp.AutoMapper;
using SettingApp.SettingStartUp;
using SettingApp.Swagger;
using System;
using Utility;

namespace Teachers
{
    public class Startup
    {
        private readonly SiteSettings _siteSettings;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCustomSwagger(_siteSettings.Swagger);
            services.AddTeacherDbContext(_siteSettings.ConnectionStrings);
            services.AddCustomIdentity(_siteSettings.IdentitySettings);
            services.AddJwtAuthentication(_siteSettings.JwtSettings);
            services.AddCustomeMvc();
            services.AddAutoMapperExtension();
            services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddLogging(options => { options.SetMinimumLevel(LogLevel.Trace); });
            
            return services.BuildAutofacServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCores(_siteSettings.OriginsUrl.Url);
            app.IntializeDatabase();
            app.UseCustomExceptionHandler();
            app.UseHsts(env);
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.CustomUseEndpoints();
            app.UseCustomSwagger();
        }
    }
}
