using MyApp.Context.Contract.CQRS.Commands;
using MyApp.Context.Domain;
using MyApp.Context.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.CQRS.Commands
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand>
    {
        private readonly IUnitOfWork _uow;

        public AddProductCommandHandler(IUnitOfWork uow)
        {
            if (uow == null) throw new ArgumentNullException("UnitOfWork cannot be null");
            _uow = uow;
        }
        public void Handle(AddProductCommand command)
        {
            var repo = _uow.GetRepository<Product>();
            Product product = GetProduct(command);
            repo.Add(product);
            try
            {
                _uow.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
        private Product GetProduct(AddProductCommand command)
        {
            var product = new Product
            {
                Id = Guid.Parse(command.Id),
                Name = command.Name,
                Description = command.Description,
                Price = command.Price
            };
            return product;
        }
    }
}
