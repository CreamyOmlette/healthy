using HealthBuilder.Repositories;
using HealthBuilder.Core.Entities;
using HealthBuilder.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HealthBuilder.API
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
            services.AddControllers();
            
            services.AddDbContext<ApplicationContext>(optionsBuilder => optionsBuilder.
                UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("HealthBuilder.API")));
            
            services.AddScoped<DbContext, ApplicationContext>();
            
            services.AddScoped<IRepository<Routine>, Repository<Routine>>();
            
            services.AddScoped<IRepository<Meal>, Repository<Meal>>();
            
            services.AddScoped<IScheduledMealRepository, ScheduledMealRepository>();
            
            services.AddScoped<IScheduledRoutineRepository, ScheduledRoutineRepository>();
            
            services.AddScoped<IRepository<ScheduledActivity>, Repository<ScheduledActivity>>();
            
            services.AddAutoMapper(typeof(Startup));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication", Version = "v1" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}