using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SettingApp.SettingStartUp
{
    public static class AddCors
    {
        public static void UseCores(this IApplicationBuilder app, string originsUrl)
        {
            app.UseCors(options => {
                options.WithOrigins(originsUrl);
                options.AllowAnyHeader().AllowAnyMethod();
            });
        }
    }
}
