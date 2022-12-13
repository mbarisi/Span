using DemoSpan;
using DemoSpan.Repository.Sql;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Web;

var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

logger.Info("Starting program");
CreateWebHostBuilder(args).Build().Run();

static IWebHostBuilder CreateWebHostBuilder(string[] args)
{
  return WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
  {
  })
    .UseNLog()
    .UseStartup<Startup>()
     .ConfigureLogging(logging =>
     {
       logging.ClearProviders();
       logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
     })
    .UseKestrel(options =>
    {
      options.Limits.MaxRequestBodySize = null;
    });
}