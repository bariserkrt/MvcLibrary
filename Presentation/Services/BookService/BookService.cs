using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Presentation.Data.Context;
using Presentation.Data.Entities;
using Presentation.Models.ViewModels.BookViewModels;
using Presentation.Models.ViewModels.GenericPaginationVM;


namespace Presentation.Services.BookService
{
    public class BookService
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper mapper;
        private readonly DbSet<Book> bookDb;

        public BookService(IMapper mapper, LibraryDbContext libraryDbContext)
        {
            this.mapper = mapper;
            _libraryDbContext = libraryDbContext;
            bookDb = _libraryDbContext.Set<Book>();
        }

        public async Task AddBookAsync(CreateBookVM bookVM,CancellationToken cancellationToken)
        {
            var book = mapper.Map<Book>(bookVM);
            await bookDb.AddAsync(book,cancellationToken);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateBookAsync(UpdateBookVM bookVM, CancellationToken cancellationToken)
        {
            var originalBook = await bookDb.FindAsync(bookVM.Id,cancellationToken);
            mapper.Map(bookVM, originalBook);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<DetailBookVM> GetBookAsync(int id,CancellationToken cancellationToken)
        {
            var book = await bookDb.Include(book => book.Category).FirstOrDefaultAsync(x => x.Id  == id,cancellationToken);

            if (book is null)
                return null;

            return mapper.Map<DetailBookVM>(book);
        } //return book detail for UI

        public async Task<UpdateBookVM> GetUpdateBookVMAsync(int id, CancellationToken cancellationToken)
        {
            var book = await bookDb.FindAsync(id);

            if (book is null)
                return null;

            var categories = await _libraryDbContext.Set<Category>().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToListAsync();

            if (book.CategoryId == 0)
                book.CategoryId = null;

            var updateBookVm = mapper.Map<UpdateBookVM>(book);
            updateBookVm.Categories = categories;

            return updateBookVm;
        } //return book detail for UI

        public async Task DeleteBookAsync(int id, CancellationToken cancellationToken)
        {
            var book = await bookDb.FindAsync(id);

            bookDb.Remove(book);

            await _libraryDbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task<PaginationVM<DetailBookVM>> GetBooks(int pageNumber, int pageSize,CancellationToken cancellationToken)
        {
            var totalBooks = bookDb.Count();

            var books = await bookDb.AsNoTracking().
                               Include(book => book.Category)
                              .OrderBy(x => x.Id)
                              .Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync(cancellationToken);
            
            var detailBookVm = mapper.Map<List<DetailBookVM>>(books);

            return new PaginationVM<DetailBookVM>
            {
                Items = detailBookVm,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalBooks
            };
        } //return all books for UI
    }
}
