using FluentValidation;
using __NAME__.Models.Example;

namespace __NAME__.Api.App.Example
{
    public class NewExampleValidator : AbstractValidator<NewExampleModel>
    {
        public NewExampleValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    public class CloseExampleValidator : AbstractValidator<CloseExampleModel>
    {
        public CloseExampleValidator()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}