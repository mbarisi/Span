using DemoSpan.Respository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Repository.Sql
{
  public interface IDataRepository
  {
    Task InsertData(Data data);
  }
}
