using FluentValidation;
using RadishV2.Shared;

namespace RadishV2.Client.Validator
{
    public class HashValidator : AbstractValidator<KeyValue>
    {
        public HashValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("Must provide a name");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Must provide a name");
            RuleFor(p => p.Value).NotNull().WithMessage("Must provide a value");
            RuleFor(p => p.Value).NotEmpty().WithMessage("Must provide a value");
        }
    }
}