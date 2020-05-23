using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Philosophers_Application.Data;
using Philosophers_Application.ModelViews;

namespace Philosophers_Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // di service
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            /* Connection strings:
             * PhiosophersDbConnectionString - MS SQL
            */
            services.AddDbContextPool<PhilosophersDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PhiosophersDbConnectionString")));
        }

        // pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Shared/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Philosophers}/{action=Index}/{id?}");
            });
        }
    }
}
