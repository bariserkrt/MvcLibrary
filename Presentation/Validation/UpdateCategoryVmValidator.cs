using FluentValidation;
using Presentation.Models.ViewModels.CategoryViewModels;

namespace Presentation.Validation
{
    public class UpdateCategoryVmValidator : AbstractValidator<UpdateCategoryVM>
    {
        public UpdateCategoryVmValidator()
        {
            RuleFor(categoryVM => categoryVM.CategoryName).NotEmpty().WithMessage("Cannot be empty");
        }
    }
}
