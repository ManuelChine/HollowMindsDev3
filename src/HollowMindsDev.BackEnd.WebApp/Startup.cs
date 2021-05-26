using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.ISilos;
using HollowMindsDev.BackEnd.ApplicationCore.Interfaces.IUsers;
using HollowMindsDev.BackEnd.Infrastructure.Data.Silos;
using HollowMindsDev.BackEnd.Infrastructure.Data.Users;
using HollowMindsDev.BackEnd.Services.Interfaces.Allert;
using HollowMindsDev.BackEnd.Services.Interfaces.ISilos;
using HollowMindsDev.BackEnd.Services.Interfaces.IUsers;
using HollowMindsDev.BackEnd.Services.Interfaces.ViewModel;
using HollowMindsDev.BackEnd.Services.Services.Allert;
using HollowMindsDev.BackEnd.Services.Services.Silos;
using HollowMindsDev.BackEnd.Services.Services.Users;
using HollowMindsDev.BackEnd.Services.Services.ViewModel;
using HollowMindsDev.BackEnd.WebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.WebApp
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("Database"), new MySqlServerVersion(new Version(8, 0, 16))));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();

            services.AddTransient<ISiloRepository, SiloRepository>();
            services.AddTransient<IMeasurementRepository, MeasurementRepository>();

            services.AddTransient<IBlockRepository, BlockRepository>();
            services.AddTransient<ILimitRepository, LimitRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ISiloService, SiloService>();
            services.AddTransient<IMeasurementService, MeasurementService>();
            services.AddTransient<IMeasurementModelService, MeasurementModelService>();
            services.AddTransient<IAllertService, AllertService>();

            services.AddTransient<IBlockService, BlockService>();
            services.AddTransient<ILimitService, LimitService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
