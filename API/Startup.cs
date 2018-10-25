using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using API.Models.EntityFramework;

namespace API
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
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Configure Swagger             
            services.AddSwaggerGen(c =>            
            {                 
                c.SwaggerDoc("v1", new Info
                    {
                    Title = "TP3 API Documentation", Version = "v1",
                    // You can also set Description, Contact, License, TOS...
                    });
                    // Configure Swagger to use the xml documentation file                 
                    var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                    c.IncludeXmlComments(xmlFile);
            });
            services.AddDbContext<FilmRatingsDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FilmRatingsDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
                { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TP3 API Documentation");
                });
        }
    }
}
