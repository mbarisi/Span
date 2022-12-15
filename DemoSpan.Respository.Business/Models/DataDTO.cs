namespace DemoSpan.Respository.Business.Models
{
  public class DataDTO
  {
    public string Name { get; set; }
    public string LastName { get; set; }
    public string PostCode { get; set; }
    public bool InvalidFormat { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }

    public static DataDTO FromCsv(string csvLine)
    {
      string[] values = csvLine.Split(';');
      DataDTO dto = new DataDTO();
      dto.Name = values[0];
      dto.LastName = values[1];
      dto.PostCode = values[2];
      dto.City = values[3];
      dto.PhoneNumber = values[4];
      dto.InvalidFormat = dto.PostCode.All(char.IsDigit) || dto.PostCode.Length == 5 ? false : true;
      return dto;
    }
  }
}
