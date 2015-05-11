using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Http;
using Carp.Data.Abstractions;
using Carp.Data.TestData;

namespace Carp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddMvc();
            services.AddSingleton<IUserProvider, TestUserProvider>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();
            
            app.UseCookieAuthentication(o => 
            {
                o.AutomaticAuthentication = true;
                o.LoginPath = new PathString("/");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseWelcomePage();
        }
    }
}