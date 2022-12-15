namespace DemoSpan.Common
{
  public class ListResponse<T> : BaseResponse
  {
    public ListResponse()
    {
    }

    public ListResponse(IEnumerable<T> result)
    {
      Result = result;
    }

    public ListResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ListResponse(IEnumerable<T> result, Guid correlationId) : base(correlationId)
    {
      Result = result;
    }

    public IEnumerable<T> Result { get; set; }
  }
}