using DemoSpan.Respository.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Repository.Sql
{
  public class DataDbContext : DbContext
  {
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

    public DbSet<Data> Data { get; set; }
  }
}
