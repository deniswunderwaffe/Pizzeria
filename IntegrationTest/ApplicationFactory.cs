using System;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Infrastructure.Data;

namespace IntegrationTest
{
    public class ApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
    {
	    protected override void ConfigureWebHost(IWebHostBuilder builder)
	    {
		    builder.ConfigureServices(services =>
		    {
			    var descriptor = services.SingleOrDefault(
				    d => d.ServiceType ==
				         typeof(DbContextOptions<ApplicationDbContext>));
		    
			    services.Remove(descriptor);
		    
			    services.AddDbContext<ApplicationDbContext>(options =>
			    {
				    options.UseInMemoryDatabase("DbForTesting");
			    });
		    
			    var sp = services.BuildServiceProvider();
		    
			    using (var scope = sp.CreateScope())
			    {
				    var scopedServices = scope.ServiceProvider;
				    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
				    var logger = scopedServices
					    .GetRequiredService<ILogger<ApplicationFactory<TStartup>>>();
		    
				    db.Database.EnsureCreated();
		    
				    try
				    {
					    Utilities.InitializeDbForTests(db);
				    }
				    catch (Exception ex)
				    {
					    logger.LogError(ex, "An error occurred seeding the " +
					                        "database with test messages. Error: {Message}", ex.Message);
				    }
			    }
		    });
	    }
    }
}

