using DemoSpan.Common;
using DemoSpan.Respository.Business;
using DemoSpan.Respository.Business.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoSpan.Controllers
{
  [ApiController]
  [Route("data")]
  public class DataController : ControllerBase
  {
    private readonly IDataProvider _dataProvider;
    public DataController(IDataProvider dataProvider)
    {
      _dataProvider = dataProvider;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<ListResponse<DataDTO>>> GetData()
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var response = await _dataProvider.FetchData();

      //if (!response.Success)
      //  return BadRequest(response);

      return Ok(response);
    }

    [HttpPost("insert")]
    [AllowAnonymous]
    public async Task<ActionResult<Response<EmptyResponseDto>>> SaveData([FromBody] List<DataDTO> dataDTOs)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var response = await _dataProvider.StoreData(dataDTOs);

      //if (!response.Success)
      //  return BadRequest(response);

      return Ok(response);
    }
  }
}
