using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLRouteFinder.Data;
using GLRouterFinder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace GLRouteFinder
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

           
            services.AddDbContext<DbContextMain>(options =>options.UseSqlServer(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "GLRouteFinder API", Version = "v1" });
            });

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped(typeof(IRouterFinder), typeof(RouterFinder));
            services.AddScoped(typeof(IDapperManager), typeof(DapperManager));
            services.AddScoped(typeof(IGLRouterFinderServices), typeof(GLRouterFinderServices));
            services.AddScoped(typeof(IGLRouterFinderRepository), typeof(GLRouteFinderRepository));
            services.AddScoped(typeof(IDataBaseFactory), typeof(DataBaseFactory));
            services.AddScoped(typeof(IHasNeighbours<Node>),typeof(Node));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GLRouteFinderAPI");
                });

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
