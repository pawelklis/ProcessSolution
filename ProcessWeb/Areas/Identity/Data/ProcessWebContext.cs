using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessWeb.Areas.Identity.Data;

namespace ProcessWeb.Data
{
    public class IdentityUser //: DbContext
    {
        //public IdentityUser(DbContextOptions<IdentityUser> options)
        //    : base(options)
        //{
            
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    string mySqlConnectionStr = "Server=localhost;Database=blazcor;Uid=root;Pwd=mayday1";
        //    options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
        //}

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}
    }
}
