using FluentValidation;
using RadishV2.Shared;

namespace RadishV2.Client.Validator
{
    public class SetValidator : AbstractValidator<KeyValue>
    {
        public SetValidator()
        {
            RuleFor(p => p.Value).NotNull().WithMessage("Must provide a value");
            RuleFor(p => p.Value).NotEmpty().WithMessage("Must provide a value");
        }
    }
}