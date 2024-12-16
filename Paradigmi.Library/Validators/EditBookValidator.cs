using FluentValidation;
using Paradigmi.Library.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Validators
{
    public class EditBookValidator : AbstractValidator<EditBookRequest>
    {
        public EditBookValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("The Id field cannot be empty")
                .GreaterThan(0)
                .WithMessage("The Id field must be greater than 0");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The Name field cannot be empty")
                .NotNull()
                .WithMessage("The Name field cannot be null");
            RuleFor(x => x.Author)
               .NotEmpty()
               .WithMessage("The Author field cannot be empty")
               .NotNull()
               .WithMessage("The Author field cannot be null");
            RuleFor(x => x.Editor)
                .NotEmpty()
                .WithMessage("The Editor field cannot be empty")
                .NotNull()
                .WithMessage("The Author field cannot be null");
            RuleFor(x => x.PublicationDate)
               .NotEmpty()
               .WithMessage("The PublicationDate field cannot be empty")
               .NotNull()
               .WithMessage("The PublicationDate field cannot be null");
        }
    }
}
