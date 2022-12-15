using DemoSpan.Common;
using DemoSpan.Repository.Sql;
using DemoSpan.Respository.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace DemoSpan.Respository.Business
{
  public class DataProvider : IDataProvider
  {
    private readonly IConfiguration _configuration;
    private readonly ILogger<DataProvider> _logger;
    private readonly IMapper _mapper;
    private readonly IDataRepository _dataRepository;

    public DataProvider(IConfiguration configuration, DataDbContext dbContext, IMapper mapper, IDataRepository dataRepository, ILogger<DataProvider> logger)
    {
      _mapper = mapper;
      _configuration = configuration;
      _dataRepository = dataRepository;
      _logger = logger;
    }
    public async Task<ListResponse<DataDTO>> FetchData()
    {
      try
      {
        var readFile = await File.ReadAllLinesAsync(_configuration.GetSection("CsvFilePath").Value);
        var dataDTOs = readFile.Select(v => DataDTO.FromCsv(v)).ToList();

        _logger.LogInformation("Getting data from csv.");
        return new ListResponse<DataDTO> { Result = dataDTOs, Success = true };
      }

      catch (Exception ex)
      {
        var msg = "Failed to get data from csv file.";
        _logger.LogError(ex, msg);
        return new ListResponse<DataDTO> { Result = null, Success = false, Message = msg };
      }
    }

    public async Task<Response<EmptyResponseDto>> StoreData(List<DataDTO> dataDTOs)
    {
      try
      {
        foreach (var dataDTO in dataDTOs)
        {
          if(!dataDTO.InvalidFormat)
          {
            _logger.LogInformation("Preparing data for store.");
            var data = _mapper.MapFromDataDTo2Data(dataDTO);
            await _dataRepository.InsertData(data);
          }
        }
        return new Response<EmptyResponseDto>()
        {
          Success = true,
          Message = $"Data successfuly inserted."
        };
      }
      catch(Exception ex)
      {
        return new Response<EmptyResponseDto>()
        {
          Success = false,
          Message = $"Exception occurred: {ex.Message}"
        };
      }
      
    }
  }
}