using Autofac;
using Fgcm.Dale.ApplicationService.IoC;
using Fgcm.Dale.Domain.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fgcm.Dale.WebApi
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
            var settings = GetSettings();

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(settings.CorsOriginsName,
                    builder =>
                    {
                        builder.WithOrigins(settings.CorsOrigins.Split(','))
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterApplicationServiceResources();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            var settings = GetSettings();

            app.UseRouting();
            app.UseCors(settings.CorsOriginsName);
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private SettingsDto GetSettings()
        {
            return Configuration.GetSection("AppSettings").Get<SettingsDto>();
        }
    }
}