using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelFirstDatabaseusingEntitytest.Models;
using ModelFirstDatabaseusingEntitytest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ModelFirstDatabaseusingEntitytest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuation)
        {
            Configuration = configuation;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["connectionStrings:parkingSitesConnectionString"];
            services.AddDbContext<ParkingSiteDbContext>(c => c.UseSqlServer(connectionString));
            services.AddScoped<ISiteRepository,SiteRepository>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ParkingSiteDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
  

             // context.SeedDataContext();
 
            app.Run(async (context) =>
            {

                
                await context.Response.WriteAsync("Hi There");
            }
            );

        }
    }
}
