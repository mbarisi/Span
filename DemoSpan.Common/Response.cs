using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSpan.Common
{
  public class Response<T> : BaseResponse
  {
    public Response() : base()
    {
    }

    public Response(T result) : base()
    {
      Result = result;
    }

    public Response(Guid correlationId) : base(correlationId)
    {
    }

    public Response(T result, Guid correlationId) : base(correlationId)
    {
      Result = result;
    }

    public T Result { get; set; }
  }
}
