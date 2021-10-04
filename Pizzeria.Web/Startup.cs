using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Pizzeria.Core.HelperClasses.Sorting;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Services;
using Pizzeria.Infrastructure.Data;
using Pizzeria.Infrastructure.Data.RepositoryImplementations;
using Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations;
using Pizzeria.Infrastructure.Services;
using Pizzeria.Web._0Auth;

namespace Pizzeria.Web
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:messages", policy => policy.Requirements.Add(new HasScopeRequirement("read:messages", Configuration["Auth0:Domain"])));
            });

            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new
                    CamelCasePropertyNamesContractResolver();
            });
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration["Auth0:Domain"];
                    options.Audience = Configuration["Auth0:Audience"];
                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });
             services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
             
             //--------------------Services and Repositories------------------//
            services.AddScoped(typeof(IRepository<>),typeof(EfRepository<>));
            services.AddScoped(typeof(ISortHelper<>), typeof(SortHelper<>));

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            services.AddScoped<IFoodItemService,FoodItemService>();
            
            
            //--------------------Services and Repositories------------------//

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzeria.Web", Version = "v1" });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "Using the Authorization header with the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                });
            });
        }
        //TODO Можно убрать зависимость web->infrastructure добавив классы модули, которые будут подключаться здесь 
        // public void ConfigureContainer(ContainerBuilder builder)
        // {
        //     builder.RegisterModule(new DefaultCoreModule());
        //     builder.RegisterModule(new DefaultInfrastructureModule(_env.EnvironmentName == "Development"));
        // }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizzeria.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}