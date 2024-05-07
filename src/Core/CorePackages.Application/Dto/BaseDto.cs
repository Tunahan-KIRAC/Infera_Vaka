using CorePackages.Domain.Comman;

namespace CorePackages.Application.Dto;

public class BaseDto
{
    public BaseDto()
    {
        CreatedDate = DateTime.Now;
        Status = DataStatus.Inserted;
    }
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DataStatus Status { get; set; }
}
