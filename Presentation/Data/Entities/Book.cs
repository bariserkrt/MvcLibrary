namespace Presentation.Data.Entities
{
    public class Book : BaseEntity
    {
        public int? CategoryId { get; set; }
        public string? BookName { get; set; }
        public int PageCount { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }
    }
}
