using DemoSpan.Respository.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Repository.Sql
{
  public class DataRepository : IDataRepository
  {
    private readonly DataDbContext _dbContext;
    private readonly ILogger<DataRepository> _logger;

    public DataRepository(DataDbContext dataDbContext, ILogger<DataRepository> logger)
    {
      _dbContext = dataDbContext;
      _logger = logger;
    }
    public async  Task InsertData(Data data)
    {
      try
      {
        _logger.LogInformation("Calling procedure 'insertdata' for storing data.");
        string sql = $"CALL insertdata (\'{data.Name}\', \'{data.LastName}\' ,\'{data.PostCode}\' ,\'{data.City}\', \'{data.PhoneNumber}\')";

        await _dbContext.Database.ExecuteSqlRawAsync(sql);
      }
      catch(Exception ex)
      {
        _logger.LogError($"Failed to call 'insertdata' db procedure : {ex.Message}");
        throw;
      }

    }
  }
}
