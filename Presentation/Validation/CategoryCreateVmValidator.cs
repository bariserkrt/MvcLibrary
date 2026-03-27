using FluentValidation;
using Presentation.Models.ViewModels.CategoryViewModels;

namespace Presentation.Validation
{
    public class CategoryCreateVmValidator : AbstractValidator<CreateCategoryVM>
    {
        public CategoryCreateVmValidator()
        {
            RuleFor(categoryVM => categoryVM.CategoryName).NotEmpty().WithMessage("Cannot be empty");
        }
    }
}
