using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters.Extensions;

namespace SettingApp
{
    public static class AddMvc
    {
        public static void AddCustomeMvc(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddApiExplorer();

        }
    }
}
