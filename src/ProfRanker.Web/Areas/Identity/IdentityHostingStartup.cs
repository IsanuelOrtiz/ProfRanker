using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfRanker.Web.Areas.Identity.Data;
using ProfRanker.Web.Models;

[assembly: HostingStartup(typeof(ProfRanker.Web.Areas.Identity.IdentityHostingStartup))]
namespace ProfRanker.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DataContex>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DataContexConnection")));

                services.AddDefaultIdentity<AppUser>()
                    .AddEntityFrameworkStores<DataContex>();
            });
        }
    }
}