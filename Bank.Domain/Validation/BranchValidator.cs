using Bank.Domain.Entities;
using FluentValidation;

namespace Bank.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor( x => x.Name ).NotEmpty().MaximumLength(25);
            RuleFor(x => x.Customers).NotEmpty();
        }
    }
}
