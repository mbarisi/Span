using DemoSpan.Common;
using DemoSpan.Respository.Business.Models;

namespace DemoSpan.Respository.Business
{
  public interface IDataProvider
  {
    Task<ListResponse<DataDTO>> FetchData();
    Task<Response<EmptyResponseDto>> StoreData(List<DataDTO> dataDTOs);
  }
}