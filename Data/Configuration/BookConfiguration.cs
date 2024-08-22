using EfCoreSoftDelete.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreSoftDelete.Data.Configuration;

public class BookConfiguration :  IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.IsDeleted);
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasQueryFilter(e => !e.IsDeleted);
    }
}