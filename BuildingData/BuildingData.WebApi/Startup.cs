using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingData.Repository;
using BuildingData.Repository.Interface;
using BuildingData.Repository.Repo;
using BuildingData.Service;
using BuildingData.Service.Interface;
using BuildingData.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BuildingData.WebApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });
            services.AddControllers();

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBuildingDataRepo), typeof(BuildingDataRepo));
            services.AddScoped(typeof(IObjectDataRepo), typeof(ObjectDataRepo));
            services.AddScoped(typeof(IDataFieldDataRepo), typeof(DataFieldDataRepo));
            services.AddScoped(typeof(IReadingDataRepo), typeof(ReadingDataRepo));

            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IObjectService, ObjectService>();
            services.AddTransient<IDataFieldService, DataFieldService>();
            services.AddTransient<IReadingService, ReadingService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");
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
