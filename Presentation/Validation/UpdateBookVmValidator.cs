using FluentValidation;
using Presentation.Models.ViewModels.BookViewModels;

namespace Presentation.Validation
{
    public class UpdateBookVmValidator : AbstractValidator<UpdateBookVM>
    {
        public UpdateBookVmValidator()
        {
            RuleFor(bookvm => bookvm.Author).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(bookvm => bookvm.BookName).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(bookvm => bookvm.PageCount).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(bookvm => bookvm.Description).NotEmpty().WithMessage("Cannot be empty");
        }
    }
}
