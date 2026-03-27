using Microsoft.AspNetCore.Mvc;
using Presentation.Models.ViewModels.CategoryViewModels;
using Presentation.Services.CategoryService;

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region CategoryList

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken,int pageNumber = 1, int pageSize = 7)
        {
            var categories = await categoryService.GetCategories(pageNumber, pageSize,cancellationToken);
            return View(categories);
        }

        #endregion

        #region CreateCategoryMethods

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM createCategoryVM, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await categoryService.AddCategory(createCategoryVM, cancellationToken);
                return RedirectToAction("Index");
            }
            return View(createCategoryVM);
        }

        #endregion

        #region DetailCategoryMethods

        [HttpGet]
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var detailCategoryVm = await categoryService.GetDetailCategoryVM(id,cancellationToken);

            if (detailCategoryVm is null)
                return NotFound("Category is not found!");

            return View(detailCategoryVm);
        }

        #endregion

        #region DeleteCategoryMethods

        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var detailCategoryVm = await categoryService.GetDetailCategoryVM(id, cancellationToken);

            if (detailCategoryVm is null)
                return NotFound("Category is not found!");

            return View(detailCategoryVm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            await categoryService.DeleteCategory(id,cancellationToken);

            return RedirectToAction("Index");
        }

        #endregion

        #region UpdateCategoryMethods

        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
        {
            var updateCategoryVm = await categoryService.GetUpdateCategoryVM(id,cancellationToken);

            if (updateCategoryVm is null)
                return NotFound("Category is not found!");

            return View(updateCategoryVm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM updateCategoryVM, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await categoryService.UpdateCategory(updateCategoryVM, cancellationToken);

                return RedirectToAction("Index");

            }
            return View(updateCategoryVM);
        }

        #endregion
    }
}
