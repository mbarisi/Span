using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Common
{
  public abstract class BaseResponse : BaseMessage
  {
    public BaseResponse(Guid correlationId) : base()
    {
      base._correlationId = correlationId;
      Errors = new List<Error>();
    }

    public BaseResponse()
    {
      Errors = new List<Error>();
    }

    public bool Success { get; set; } = false;
    public string Message { get; set; }
    public IEnumerable<Error> Errors { get; set; }

    public void AddError(Error error)
    {
      var errors = this.Errors.ToList();
      errors.Add(error);
      this.Errors = errors;
    }
  }
}
