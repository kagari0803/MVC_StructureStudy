using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_StructureStudy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //register the service here
        public void ConfigureServices(IServiceCollection services)
        {
            //register MVC to this project
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //IWebHostEnvironment env is to check if now is in the development environment
            if (env.IsDevelopment())
            {
                //developer error message
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //error message to user
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //force the user use secure line
            app.UseHttpsRedirection();
            //can use static files in wwwroot(ex:html/css/js)
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //last step
            app.UseEndpoints(endpoints =>
            {
                //endpoints about MVC (can add more like razor)
                endpoints.MapControllerRoute(
                    name: "default",
                    //default controller name=home action=Index id is optional
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
