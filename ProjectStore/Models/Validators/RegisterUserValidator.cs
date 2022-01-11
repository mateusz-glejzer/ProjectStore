using FluentValidation;
using ProjectStore.Entities;
using System.Linq;

namespace ProjectStore.Models.Validators
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserDto>
    {
        

        public RegisterUserValidator(StoreDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);
                var userNameInUse = dbContext.Users.Any(u => u.Username == value);
                var validate = emailInUse && userNameInUse;
                if (validate) 
                {
                    context.AddFailure("Email or Username", "Email or Username is taken");
                }
            });
            
        }

    }
}
