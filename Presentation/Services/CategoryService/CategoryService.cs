using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Data.Context;
using Presentation.Data.Entities;
using Presentation.Models.ViewModels.CategoryViewModels;
using Presentation.Models.ViewModels.GenericPaginationVM;

namespace Presentation.Services.CategoryService
{
    public class CategoryService
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper mapper;
        private readonly DbSet<Category> categories;

        public CategoryService(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            this.mapper = mapper;
            categories = _libraryDbContext.Set<Category>();
        }

        public async Task<List<SelectListItem>> GetCategoriesForCreateBook(CancellationToken cancellationToken)
        {
            var selectItemCategories = await categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToListAsync(cancellationToken);

            return selectItemCategories;
        }

        public async Task AddCategory(CreateCategoryVM createCategoryVM,CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(createCategoryVM);
            await categories.AddAsync(category,cancellationToken);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteCategory(int id,CancellationToken cancellationToken)
        {
            var deleteCategory = await categories.FindAsync(id, cancellationToken);
            
            categories.Remove(deleteCategory);

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateCategory(UpdateCategoryVM updateCategoryVM,CancellationToken cancellationToken)
        {
            var originalCategory = await categories.FindAsync(updateCategoryVM.Id,cancellationToken);
            mapper.Map(updateCategoryVM, originalCategory);

            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }
    
        public async Task<DetailCategoryVM> GetDetailCategoryVM(int id,CancellationToken cancellationToken)
        {
            var category = await categories.FindAsync(id,cancellationToken);

            if (category == null)
                    return null;
            
            var categoryVM = mapper.Map<DetailCategoryVM>(category);
        
            return categoryVM;
        }

        public async Task<UpdateCategoryVM> GetUpdateCategoryVM(int id, CancellationToken cancellationToken)
        {
            var category = await categories.FindAsync(id, cancellationToken);

            if (category == null)
                return null;

            var categoryVM = mapper.Map<UpdateCategoryVM>(category);

            return categoryVM;
        }

        public async Task<PaginationVM<DetailCategoryVM>> GetCategories(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var totalCategory = categories.Count();
            var allCategories = await categories.AsNoTracking().OrderBy(x => x.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            var CategoryDetailVms = mapper.Map<List<DetailCategoryVM>>(allCategories);

            return new PaginationVM<DetailCategoryVM>
            {
                Items = CategoryDetailVms,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCategory
            };
        }
    }
}
