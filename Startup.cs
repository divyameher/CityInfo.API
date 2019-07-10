using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace CityInfo.API
{
    public class Startup
    {
        // public static IConfigurationRoot Configuration;
        public static IConfiguration Configuration;
        public Startup(
             // IHostingEnvironment env,
             IConfiguration configuration)
        {
            // This if for ASP.Net Core < 2.2
            // var builder = new ConfigurationBuilder()
            // .SetBasePath(env.ContentRootPath)
            // .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
            // Configuration = builder.Build();

            // For .NetCore 2.2
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
            .AddMvcOptions(o => o.OutputFormatters.Add(
                new XmlDataContractSerializerOutputFormatter()
            ));
            // .AddJsonOptions(o =>
            // {
            //     // If we need to send response of API's as defined in Controller instead of lowercase
            //     // set Naming Strategy to null
            //     if (o.SerializerSettings.ContractResolver != null)
            //     {
            //         var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //         castedResolver.NamingStrategy = null;
            //     }
            // });
#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
        services.AddTransient<IMailService, CloudMailService>();
#endif
            var connectionString = Startup.Configuration["connectionStrings:cityInfoDBConnectionString"];
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CityInfoContext cityInfoContext)
        {
            // These two were already added in CreateDefaultBuilder from .NetCore 2.2
            // No need to add it again
            // loggerFactory.AddConsole();
            // loggerFactory.AddDebug();

            // loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            cityInfoContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<Entities.City, Models.CityDto>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
            });
            app.UseMvc();
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
        }
    }
}
