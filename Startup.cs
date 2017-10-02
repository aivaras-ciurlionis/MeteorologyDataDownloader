using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Hangfire;
using MeteorologyDownloader.DataRetrieval;

namespace MeteorologyDownloader
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHangfire(x => x.UseSqlServerStorage("<connection string>"));
            services.AddTransient<ICleanupHandler, CleanupHandler>();
            services.AddTransient<IImagesConcater, ImagesConcater>();
            services.AddTransient<IMeteoConnector, MeteoConnector>();
            services.AddTransient<IMeteoDataDownloader, MeteoDataDownloader>();
            services.AddTransient<INearestMinutesEstimator, NearestMinutesEstimator>();
            services.AddTransient<IRadarTileRangeDownloader, RadarTileRangeDownloader>();
            services.AddTransient<IRadarTilesDownloader, RadarTilesDownloader>();
            services.AddTransient<ISingleRadarTileDownloader, SingleRadarTileDownloader>();
            //services.AddTransient<IStorageUplader, StorageUploader>();
            //services.AddTransient<ITemperatureTilesDownloader, TemperatureTilesDownloader>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

          


            //app.UseHangfireServer();
            //app.UseHangfireDashboard();

            app.UseMvc();
        }
    }
}
