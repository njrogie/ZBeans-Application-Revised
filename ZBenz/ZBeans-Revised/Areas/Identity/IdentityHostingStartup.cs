using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZBeans_Revised.Areas.Identity.Data;
using ZBeans_Revised.Data;

[assembly: HostingStartup(typeof(ZBeans_Revised.Areas.Identity.IdentityHostingStartup))]
namespace ZBeans_Revised.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ZBeans_RevisedContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ZBeans_RevisedContextConnection")));

                services.AddDefaultIdentity<ZBeans_RevisedUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ZBeans_RevisedContext>();
            });
        }
    }
}