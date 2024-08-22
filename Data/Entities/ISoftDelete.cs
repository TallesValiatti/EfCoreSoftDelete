namespace EfCoreSoftDelete.Data.Entities;

public interface ISoftDelete
{
    public DateTime? DeletedAt { get; set; }

    public bool IsDeleted { get; set; }
}