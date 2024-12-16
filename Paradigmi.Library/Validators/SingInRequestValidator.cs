using Paradigmi.Library.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Paradigmi.Library.Application.Validators
{
    public class SingInRequestValidator : AbstractValidator<SignInRequest>
    {
        public SingInRequestValidator()
        {
            RuleFor(m => m.Email)
                .NotNull()
                .WithMessage("The Email field cannot be nullo")
                .NotEmpty()
                .WithMessage("The Email field cannot be empty")
                .Custom((email, context) =>
                {
                    var regEx = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
                    if (regEx.IsMatch(email) == false)
                        context.AddFailure("The field must contain an email of the correct format");
                });
            RuleFor(m => m.Password)
                .NotNull()
                .WithMessage("The Password field cannot be null")
                .NotEmpty()
                .WithMessage("The Password field cannot be empty")
                .Custom((value, context) =>
                {
                    var regEx = new Regex("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$");
                    if (regEx.IsMatch(value) == false)
                    {
                        context.AddFailure("The password field must be at least 6 characters long and must contain at least one uppercase character, one lowercase character, one number and one special character");
                    }
                });
            RuleFor(m => m.Name)
                .NotNull()
                .WithMessage("The Name field cannot be null")
                .NotEmpty()
                .WithMessage("The Name field cannot be empty");
            RuleFor(m => m.Surname)
                .NotNull()
                .WithMessage("The Surname field cannot be null")
                .NotEmpty()
                .WithMessage("The Surname field cannot be empty");

        }

    }
}
