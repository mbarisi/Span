using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoSpan.Repository.Sql
{
  public static class SqlRepositoryConfig
  {
    public static void RegisterSqlDependecies(this IServiceCollection serviceCollection, IConfiguration Configuration)
    {
      // Setup DB 
      serviceCollection.AddDbContext<DataDbContext>
           (o => o.UseNpgsql(Configuration.GetSection("ConnectionStrings:PostgresSqlDatabase").Value));

      serviceCollection.AddScoped<IDataRepository, DataRepository>(); 
    }
  }
}