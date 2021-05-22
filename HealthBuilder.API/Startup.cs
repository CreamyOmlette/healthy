using System;
using System.Collections.Generic;
using System.Text;
using HealthBuilder.API.Extensions;
using HealthBuilder.API.Middleware;
using HealthBuilder.Repositories;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;
using HealthBuilder.Repositories.Contracts;
using HealthBuilder.Services;
using HealthBuilder.Services.Contracts;
using HealthBuilder.Services.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

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
            
            services.AddScoped<IRepository<User>, Repository<User>>();

            services.AddScoped<ISchedulingService, SchedulingService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMealService, MealService>();

            services.AddScoped<IRoutineService, RoutineService>();

            services.AddScoped<IRoutineRepository, RoutineRepository>();

            services.AddScoped<IMealRepository, MealRepository>();
            
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IScheduledActivityRepository, ScheduledActivityRepository<ScheduledActivity>>();

            services.AddScoped<IExerciseRepository, ExerciseRepository>();

            services.AddScoped<IUserIdentityService, UserIdentitySevice>();

            services.AddAutoMapper(typeof(MappingProfile));
            
            // For Identity  
            services.AddIdentity<UserIdentity, IdentityRole>()  
                .AddEntityFrameworkStores<ApplicationContext>()  
                .AddDefaultTokenProviders();  
  
            // Adding Authentication  
            services.AddAuthentication(options =>  
                {  
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;  
                })
                // Adding Jwt Bearer  
                .AddJwtBearer(options =>  
                {  
                    options.SaveToken = true;  
                    options.RequireHttpsMetadata = false;  
                    options.TokenValidationParameters = new TokenValidationParameters()  
                    {  
                        ValidateIssuer = true,  
                        ValidateAudience = true,  
                        ValidAudience = Configuration["JWT:ValidAudience"],  
                        ValidIssuer = Configuration["JWT:ValidIssuer"],  
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))  
                    };  
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5000/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5000/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api1", "Demo API - full access"}
                            }
                        }
                    }
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));
            }
            
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}