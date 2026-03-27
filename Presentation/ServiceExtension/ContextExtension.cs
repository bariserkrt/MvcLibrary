using Presentation.Data.Context;
using Presentation.Map;
using Presentation.Services.BookService;
using Presentation.Services.CategoryService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Presentation.Validation;

namespace Presentation.ServiceExtension
{
    public static class ContextExtension 
    {
        public static IServiceCollection ContextServiceExtension(this IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>();
            services.AddScoped<CategoryService>();
            services.AddScoped<BookService>();
            services.AddAutoMapper(map => map.AddMaps(typeof(LibraryMap)));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            return services;
        }
    }
}
