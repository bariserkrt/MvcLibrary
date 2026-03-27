using FluentValidation;
using Presentation.Data.Entities;
using Presentation.Models.ViewModels.BookViewModels;

namespace Presentation.Validation
{
    public class CreateBookVmValidator : AbstractValidator<CreateBookVM>
    {
        public CreateBookVmValidator()
        {
            RuleFor(bookvm => bookvm.Author).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(bookvm => bookvm.BookName).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(bookvm => bookvm.PageCount).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(bookvm => bookvm.Description).NotEmpty().WithMessage("Cannot be empty");
        }
    }
}
