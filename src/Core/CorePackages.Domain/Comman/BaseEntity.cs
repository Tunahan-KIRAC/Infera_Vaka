namespace CorePackages.Domain.Comman;

public class BaseEntity
{
    public BaseEntity()
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
