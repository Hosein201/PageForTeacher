using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Utility;

namespace SettingApp.Swagger
{
    public static class AddSwaggerExtensions
    {
        public static void AddCustomSwagger(this IServiceCollection service, SwaggerConfiguration swaggerConfiguration)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Collection Apis",
                    Description = "This is Collection of apis for this project ",
                });

                options.OperationFilter<AuthorizationHeaderSwagger>();

                #region xml
                // var xmlPath = Path.Combine(swaggerConfiguration.UriSwagger, "MyApi.xml");
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //options.IncludeXmlComments(xmlPath);
                #endregion
            });
        }

        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
