using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcessWeb.Data;

namespace ProcessWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<UserState>();
            services.AddScoped<PassData>();//scoped for server side
            //services.AddSingleton<PassData>();//scoped for client side

            services.AddSingleton<SingletonService>();
            services.AddTransient<TransientService>();
            services.AddScoped<ScopedService>();


            #region Connection String
            string mySqlConnectionStr = Configuration.GetConnectionString("mysql");
            services.AddDbContext<AppDBContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            //services.AddDefaultIdentity<Data.IdentityUser>(options => {
            //    options.SignIn.RequireConfirmedAccount = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 10;
            //    options.Password.RequireLowercase = true;
            //})
            // .AddEntityFrameworkStores<AppDBContext>();

            services.AddControllers();
            #endregion
        }

    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
