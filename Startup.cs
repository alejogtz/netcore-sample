using FilemanagerDemo.DatabaseAccess;
using FilemanagerDemo.Infraestructura.DatabaseAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FilemanagerDemo
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /* ---------------------------------------------
             *              CORS
             * --------------------------------------------- */
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .WithMethods("PUT", "GET", "OPTIONS", "POST");
                                  });
            });

            services.AddControllers();

            /* ---------------------------------------------
             *              SWAGGER
             * --------------------------------------------- */
            services.AddSwaggerGen(a => a.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" }));

            /* ---------------------------------------------
             *              DI (DEPENDENCY INJECTION)
             * --------------------------------------------- */
            services.AddScoped<IPersonasStoredFunctions, PersonasStoredFunctions>();

            /* ---------------------------------------------
             *              OPTIONS
             * --------------------------------------------- */
            services.Configure<LocalFileStorageOptions>(Configuration.GetSection("LocalStorage"));
            services.Configure<DatabaseOptions>(Configuration.GetSection("Database"));
            services.AddSingleton<LocalFileStorageOptions>();
            services.AddSingleton<DatabaseOptions>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                /**
                 * SWAGGER CONFIGURATION
                 */
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Version 1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(); // ENABLE CORS CONFIG
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
