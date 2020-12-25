using FluentValidation;
using RedisKeyTool.Shared;

namespace RedisKeyTool.Client.Validator
{
    public class ListValidator : AbstractValidator<KeyValue>
    {
        public ListValidator()
        {
            RuleFor(p => p.Value).NotNull().WithMessage("Must provide a value");
            RuleFor(p => p.Value).NotEmpty().WithMessage("Must provide a value");
        }
    }
}