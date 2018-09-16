using FluentValidation; 

namespace EpochApi.Validators
{
    public class RegistrationValidator : AbstractValidator<Models.Account>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(4, 12);
            RuleFor(x => x.Password).NotNull().Length(6, 16);
            RuleFor(x => x.Email).NotNull().EmailAddress();
        }
    }
}
