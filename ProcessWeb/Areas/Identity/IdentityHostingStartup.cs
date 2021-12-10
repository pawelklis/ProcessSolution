using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessWeb.Areas.Identity.Data;
using ProcessWeb.Data;
using IdentityUser = ProcessWeb.Data.IdentityUser;

[assembly: HostingStartup(typeof(ProcessWeb.Areas.Identity.IdentityHostingStartup))]
namespace ProcessWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            return; 

            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<AppDBContext>(options =>
            //        options.UseMySql(
            //            context.Configuration.GetConnectionString("mysql"), ServerVersion.AutoDetect(context.Configuration.GetConnectionString("mysql"))));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    //AddEntityFrameworkStores<IdentityUser>();
            //});
        }
    }
}