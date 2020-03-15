using FluentValidation;
using MyApp.WebApi.Contract.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi.RequestValidators
{
    public class AddProductRequestValidator:AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product name is required")
                .Length(0, 200);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product description is required.");


            RuleFor(x => x.Price)
                .NotNull();


        }
    }
}
