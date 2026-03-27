using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Data.Entities;

namespace Presentation.Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
            new Category { Id = 1, CategoryName = "Fiction" },
            new Category { Id = 2, CategoryName = "Science" },
            new Category { Id = 3, CategoryName = "History" },
            new Category { Id = 4, CategoryName = "Fantasy" },
            new Category { Id = 5, CategoryName = "Biography" }
            );
        }
    }
}
