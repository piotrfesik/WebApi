using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApplication.Api.Configuration.AutoMapper;
using WebApplication.Api.Infrastructure.ExceptionMiddleware;
using WebApplication.Data.Context;
using WebApplication.Data.Repositories.Configurations;
using WebApplication.Data.Repositories.Laptops;
using WebApplication.Services.Services.ConfigurationService;
using WebApplication.Services.Services.LaptopService;
using WebApplication.Services.Services.ShoppingBasket;

namespace WebApplication.Api
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
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["sql"],
                        migration => migration.MigrationsAssembly(migrationsAssembly))
                    .EnableSensitiveDataLogging()
                    .UseLazyLoadingProxies(false)
                    .LogTo(Console.WriteLine)
            );
            services.AddControllers();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApplication.Api", Version = "v1"}); });

            services.AddAutoMapper(opt => { opt.AddProfile<MappingProfile>(); },
                typeof(Startup));

            services.AddScoped<IConfigurationItemRepository, ConfigurationItemRepository>();
            services.AddScoped<IConfigurationTypeRepository, ConfigurationTypeRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ILaptopRepository, LaptopRepository>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ILaptopService, LaptopService>();
            services.AddScoped<IShoppingBasketService, ShoppingBasketService>();
            services.AddScoped<IBasketRepository ,BasketRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication.Api v1"));
            }
            
            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}