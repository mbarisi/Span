using DemoSpan.Respository.Business.Models;
using DemoSpan.Respository.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Respository.Business
{
  public interface IMapper
  {
    Data MapFromDataDTo2Data(DataDTO dataDTO);
  }
  public class Mapper : IMapper
  {
    public Data MapFromDataDTo2Data(DataDTO dataDTO)
    {
      return new Data{
        Name = dataDTO.Name,
        LastName = dataDTO.LastName,
        City = dataDTO.City,
        PostCode = dataDTO.PostCode,
        PhoneNumber = dataDTO.PhoneNumber
      };
    }
  }
}
