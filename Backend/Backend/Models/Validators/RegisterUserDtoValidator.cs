using Backend.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(AnimalsDbContext dbContext)
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);
            RuleFor(x => x.Login).Custom((value, context) =>
            {
                var loginInUse = dbContext.Users.Any(u => u.Login == value);
                if (loginInUse)
                {
                    context.AddFailure("Login", "login is taken");
                }
            });
        }
    }
}
