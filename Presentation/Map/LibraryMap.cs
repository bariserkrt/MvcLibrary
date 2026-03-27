using AutoMapper;
using Presentation.Data.Entities;
using Presentation.Models.ViewModels.BookViewModels;
using Presentation.Models.ViewModels.CategoryViewModels;

namespace Presentation.Map
{
    public class LibraryMap : Profile
    {
        public LibraryMap()
        {
            CreateMap<CreateBookVM,Book>().ReverseMap();
            CreateMap<Book, DetailBookVM>().ForMember(vm => vm.CategoryName , opt => opt.MapFrom(book => book.Category.CategoryName)).ReverseMap();
            CreateMap<UpdateBookVM, Book>().ForMember(book => book.CreatedDate, opt => opt.Ignore()).ReverseMap();
            CreateMap<Category,CreateCategoryVM>().ReverseMap();
            CreateMap<Category, DetailCategoryVM>().ReverseMap();
            CreateMap<UpdateCategoryVM,Category>().ForMember(category => category.CreatedDate, opt => opt.Ignore()).ReverseMap();
        }
    }
}
