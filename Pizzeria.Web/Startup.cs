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
using Pizzeria.Core.Exceptions;
using Pizzeria.Core.Exceptions.Extensions;
using Pizzeria.Core.HelperClasses.Sorting;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;
using Pizzeria.Core.Services;
using Pizzeria.Infrastructure.Data;
using Pizzeria.Infrastructure.Data.RepositoryImplementations;
using Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations;
using Pizzeria.Infrastructure.Services;
using Pizzeria.Web._0Auth;
using Pizzeria.Web.DependencyInjectionExtensions;

namespace Pizzeria.Web
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy("use:everything",
                    policy => policy.Requirements.Add(new HasScopeRequirement("use:everything",
                        Configuration["Auth0:Domain"])));
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

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new
                    CamelCasePropertyNamesContractResolver();
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(ISortHelper<>), typeof(SortHelper<>));
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddRepositoryDependencyGroup();
            services.AddServiceDependencyGroup();
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerExtension();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizzeria.Web v1"));
            }
            else
            {
                //app.UseExceptionHandler("/error");
                //TODO какой подход лучше?
                app.ConfigureExceptionHandler();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}