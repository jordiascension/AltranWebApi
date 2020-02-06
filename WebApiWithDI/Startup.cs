using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebApiWithDI.Initializers;

namespace WebApiWithDI
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var dom = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
            .AddEnvironmentVariables()
            .Build();
            Configuration = dom;

            CurrentEnvironment = env;
        }

        public IWebHostEnvironment CurrentEnvironment { get; set; }

        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Comentar en la generación de código
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.User);
            if (environment == "Production")
            {
                 services.AddDbContext<SqlServerTodoContext>(opts => 
                 opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
             }
             else
             {
                 services.AddDbContext<TodoContext>(opt =>
                    opt.UseInMemoryDatabase("TodoList"));

             }

            /*services.AddDbContext<SqlServerTodoContext>(opts =>
                opts.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            */
            services.AddControllers();
  
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
