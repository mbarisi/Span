using DemoSpan.Repository.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Respository.Business
{
  public static class BusinessConfig
  {
    public static void RegisterBusinessDependecies(this IServiceCollection services, IConfiguration Configuration)
    {
      services.AddScoped<IMapper, Mapper>();
      services.AddScoped<IDataProvider, DataProvider>();
      services.RegisterSqlDependecies(Configuration);
    }
  }
}
