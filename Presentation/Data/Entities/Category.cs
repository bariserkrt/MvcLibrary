namespace Presentation.Data.Entities
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get; set; }
        public List<Book>? Books { get; set; }
    }
}
