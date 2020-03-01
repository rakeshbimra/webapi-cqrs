using FluentValidation;
using MyApp.Context.Contract.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Commands.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product name is required");
        }
    }
}
