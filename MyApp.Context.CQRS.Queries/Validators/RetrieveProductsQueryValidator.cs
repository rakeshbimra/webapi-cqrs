using FluentValidation;
using MyApp.Context.Contract.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Queries.Validators
{
    public class RetrieveProductsQueryValidator : AbstractValidator<RetrieveProductsQuery>
    {
        public RetrieveProductsQueryValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("ProductId is required");
        }
    }
}
