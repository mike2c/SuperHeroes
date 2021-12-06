using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string baseUrl = Configuration.GetValue<string>("BaseUrl");
            string apiKey = Configuration.GetValue<string>("ApiKey");

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddTransient<IHeroRepository>(x => new HeroApiRepository(baseUrl, apiKey));
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();    
                app.UseStatusCodePagesWithRedirects("/error/{0}");
            }
            else
            {                
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();            
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Hero}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "character", "character/{id}", new { controller = "Hero", action = "Character" });
            });
        }
    }
}
