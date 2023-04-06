using Blog.Net.Entities.Concrete;
using FluentValidation;

namespace Blog.Net.Services.Validation.FluentValidation
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();
            RuleFor(p => p.Text).NotEmpty();
        }
    }
}
