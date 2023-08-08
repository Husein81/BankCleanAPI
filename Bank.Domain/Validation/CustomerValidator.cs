using FluentValidation;
using Bank.Domain.Entities;
namespace Bank.Domain.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator() 
        { 
            RuleFor( x => x.Id ).NotEmpty();
            RuleFor( x => x.Name ).NotEmpty().MaximumLength(25);
            RuleFor( x =>x.Branches).NotEmpty();
        }
    }
}
