using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portal.Application.Common;
using Portal.Application.FoodApplication;
using Portal.Application.FoodApplication.Commands;
using Portal.Application.Foods;
using Portal.Domain.Identity;
using Portal.Persisatance;
using FluentValidation;

namespace Portal.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<PortalDbContext>(options =>
            //{
            //    options.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=portalDb_dev01;Integrated Security=True");
            //});

            services.AddDbContext<PortalDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            services.AddAutoMapper(typeof(FoodMapper).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(CreateFoodCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommonPiplineLogging<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommonValidationPipline<,>));
            services.AddValidatorsFromAssemblyContaining<CreateFoodCommandValidator>();

            services.AddTransient<IFoodService, FoodService>();

            services.AddDefaultIdentity<ApplicationUser>()
               .AddDefaultUI()
               .AddEntityFrameworkStores<PortalDbContext>();
            services.AddControllers();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            //.AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<FoodAddValidator>(); });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
