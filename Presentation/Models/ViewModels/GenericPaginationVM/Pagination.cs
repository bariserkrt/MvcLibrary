using Presentation.Models.ViewModels.CategoryViewModels;

namespace Presentation.Models.ViewModels.GenericPaginationVM
{
    public class PaginationVM<T>
    {
        public List<T>? Items { get; set; }
        public int TotalItems { get; set; } 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPage => (int) Math.Ceiling((double) TotalItems / PageSize);

    }
}
