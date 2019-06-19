using Balan.EventSourcing.Serialization.Json;
using EventSourcing.Sample.Domain;
using EventSourcing.Sample.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace EventSourcing.Sample.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static ServiceProvider Container { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot config = configurationBuilder.Build();

            var configSection = config.GetSection("CosmosSettings").GetChildren();

            services.AddDbContext<SampleDbContext>(options =>
            options.UseCosmos(configSection.Where(x => x.Key == "ServiceEndpoint").FirstOrDefault().Value,
                             configSection.Where(x => x.Key == "AuthKey").FirstOrDefault().Value,
                             configSection.Where(x => x.Key == "DatabaseName").FirstOrDefault().Value));

            services
             .AddScoped<IGiftCardRepository, GiftCardRepository>()
             .AddEventSourcing(builder =>
              {
                  builder
                      .UseJsonEventSerializer()
                      .UseCosmosDbEventStore<SampleDbContext, GiftCard, Guid>()
                      ;
              });
            services.AddLogging(options =>
               options.AddDebug().SetMinimumLevel(LogLevel.Trace));

            Container = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
