using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Data.Entities;

namespace Presentation.Models.ViewModels.BookViewModels
{
    public class CreateBookVM
    {
        public string? BookName { get; set; }
        public int PageCount { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
