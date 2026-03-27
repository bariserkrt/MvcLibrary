using Microsoft.AspNetCore.Mvc;
using Presentation.Models.ViewModels.BookViewModels;
using Presentation.Services.BookService;
using Presentation.Services.CategoryService;

namespace Presentation.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;
        private readonly CategoryService categoryService;

        public BookController(BookService bookService, CategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }

        #region BookList

        public async Task<IActionResult> Index(CancellationToken cancellationToken,int pageNumber = 1, int pageSize = 7)  
        {
            var detailBookVMs = await bookService.GetBooks(pageNumber, pageSize,cancellationToken);

            return View(detailBookVMs);
        }


        #endregion

        #region CreateBookMethods

        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellation)
        {
            var categories = await categoryService.GetCategoriesForCreateBook(cancellation);
            
            return View(new CreateBookVM() { Categories = categories});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookVM createBookVM, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBookAsync(createBookVM, cancellationToken);
                return RedirectToAction("Index");
            }
            else 
            {
                createBookVM.Categories = await categoryService.GetCategoriesForCreateBook(cancellationToken);
                return View(createBookVM);
            }
        }

        #endregion

        #region DetailBookMethods

        [HttpGet]
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var detailBookVm = await bookService.GetBookAsync(id, cancellationToken);

            if (detailBookVm is null)
                return NotFound("Book not found!");

            return View(detailBookVm);
        }

        #endregion

        #region DeleteBookMethods

        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var detailBookVm = await bookService.GetBookAsync(id, cancellationToken);

            if(detailBookVm is null)
                return NotFound("Book not found!");

            return View(detailBookVm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            await bookService.DeleteBookAsync(id,cancellationToken);
            return RedirectToAction("Index");
        }

        #endregion

        #region UpdateBookMethods

        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var updateBookVm = await bookService.GetUpdateBookVMAsync(id, cancellationToken);

            if (updateBookVm is null)
                return NotFound("Book not found!");

            return View(updateBookVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookVM updateBookVM, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await bookService.UpdateBookAsync(updateBookVM, cancellationToken);
                return RedirectToAction("Index");
            }

            updateBookVM.Categories = await categoryService.GetCategoriesForCreateBook(cancellationToken);
            return View(updateBookVM);
        }

        #endregion

    }
}
