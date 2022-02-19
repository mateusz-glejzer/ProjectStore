
using ProjectStore.Entities;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectStore.Services;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using ProjectStore.Models;
using ProjectStore.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProjectStore.Middleware;
using Microsoft.AspNetCore.Authorization;
using ProjectStore.Authorization;
using MediatR;
using StackExchange.Redis;

namespace ProjectStore
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
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings);
            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }
            ).AddJwtBearer(cfg=>
            { 
                cfg.RequireHttpsMetadata = true;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
                };
            
            });
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
            services.AddControllersWithViews().AddFluentValidation();
            services.AddSwaggerGen();
            services.AddDbContext<StoreDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("ProjectStoreDbConnection")));
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<StoreSeeder>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IProductService, ProductService>();
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection")));
            services.AddScoped<ICachceService, RedisCacheService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,StoreSeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            seeder.Seed();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "https://localhost:44378/swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
