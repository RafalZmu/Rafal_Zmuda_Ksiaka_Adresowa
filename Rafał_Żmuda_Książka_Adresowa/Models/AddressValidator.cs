using FluentValidation;

namespace Rafał_Żmuda_Książka_Adresowa.Models
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field can not be empty");
            RuleFor(x => x.SecondName).NotEmpty().WithMessage("Second name field can not be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect email address");
            RuleFor(x => x.City).NotEmpty().WithMessage("City field can not be empty");
        }
    }
}