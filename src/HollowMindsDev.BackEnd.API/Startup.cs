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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HollowMindsDev.BackEnd.API", Version = "v1" });
            });

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
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HollowMindsDev.BackEnd.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
