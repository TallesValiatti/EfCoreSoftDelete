namespace EfCoreSoftDelete.Data.Entities;

public class Book : IEntity, ISoftDelete
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
}