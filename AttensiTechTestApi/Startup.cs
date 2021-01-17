using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AttensiTechTestApi.Services;
using AutoMapper;
using Common.Helpers;
using Common.Helpers.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Connection.Abstract;
using Persistence.Repository;
using Persistence.Repository.Abstract;
using AttensiTechTestApi.Services.Abstract;
using DbConnection = Persistence.Connection.DbConnection;

namespace AttensiTechTestApi
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
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IRecordsRepository, RecordsRepository>();
            services.AddTransient<IRecordsService, RecordsService>();
            services.AddTransient<ISummaryRepository, SummaryRepository>();
            services.AddTransient<ISummaryService, SummaryService>();

            services.AddTransient<IEnvironmentHelper, EnvironmentHelper>();
            services.AddTransient<IDbConnection, DbConnection>();
            

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
