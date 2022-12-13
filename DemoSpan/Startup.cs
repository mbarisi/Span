using DemoSpan.Repository.Sql;
using DemoSpan.Respository.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DemoSpan
{
  public class Startup
  {
    public IConfiguration configRoot
    {
      get;
    }
    public Startup(IConfiguration configuration)
    {
      configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.RegisterBusinessDependecies(configRoot);
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.ConfigureNLog("nlog.config");
      loggerFactory.AddNLog();
      var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();

      using (var serviceScope = serviceScopeFactory.CreateScope())
      {
        var dbContext = serviceScope.ServiceProvider.GetService<DataDbContext>();
        dbContext.Database.EnsureCreated();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
