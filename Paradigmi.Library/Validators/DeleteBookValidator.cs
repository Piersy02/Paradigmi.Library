using Paradigmi.Library.Application.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Application.Validators
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookRequest>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("The Name field cannot be empty")
                .GreaterThan(0)
                .WithMessage("The Id field must be greater than 0");
        }
    }
}
