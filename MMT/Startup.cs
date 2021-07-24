using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MMT.Models.DB;
using System;
using System.IO;
using System.Reflection;


namespace MMTDeliveries
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

            // Register SQL database configuration context as services.
            //TODO: extend for other environments

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<IMMTContext, MMTContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Orders"));
            });


            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MMT Deliveries API",
                    Description = "An API to return customer order details ",
                    TermsOfService = new Uri("https://mmt/api/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Some Helper",
                        Email = "apicontact@mmt.com",
                        Url = new Uri("https://mmt/contacts/somehrlper"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //use JSON v2 to support Power Apps
                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMT API");
                    c.RoutePrefix = string.Empty; //show swagger at route
                });
            }

            //TODO: add error handler page for production

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
