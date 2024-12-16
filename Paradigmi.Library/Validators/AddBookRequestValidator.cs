using Paradigmi.Library.Application.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Validators
{
    public class AddBookRequestValidator : AbstractValidator<AddBookRequest>
    {
        public AddBookRequestValidator()
        {
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
                .WithMessage("The Editor field cannot be null");
            RuleFor(x => x.PublicationDate)
               .NotEmpty()
               .WithMessage("The PublicationDate field cannot be empty")
               .NotNull()
               .WithMessage("The PublicationDate field cannot be null");
        }
    }
}
