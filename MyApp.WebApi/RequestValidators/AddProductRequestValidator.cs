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
                .Length(0, 200);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotNull();


        }
    }
}
