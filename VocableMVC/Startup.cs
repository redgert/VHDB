using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using VocableMVC.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VocableMVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = @"Server=tcp:westeuropevhdbsqlserver.database.windows.net,1433; Initial Catalog=vhdb; Persist Security Info=False; User ID=vhdbadmin; Password=niklas23serutsom34!; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;";

            //Konfigurera EF att arbeta mot (MS-Klassen) IdentityDbContext
            services.AddDbContext<VHDBContext>(
                options => options.UseSqlServer(connString));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Cookies.ApplicationCookie.LoginPath = "/account/login";
            })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseIdentity();

            app.UseMvcWithDefaultRoute();
        }
    }
}
