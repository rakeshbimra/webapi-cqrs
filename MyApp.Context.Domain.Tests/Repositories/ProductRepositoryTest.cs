using Microsoft.EntityFrameworkCore;
using Moq;
using MyApp.Context.Domain.Model;
using MyApp.Context.Domain.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Tests.Repositories
{
    
    public class ProductRepositoryTest
    {
        [Test]
        public void ProductRepository_Add()
        {
            //Arrange
            var productMock = new Mock<Product>();
            var contextMock = new Mock<DbContext>();
            var productDbSetMock = new Mock<DbSet<Product>>();
            contextMock.Setup(x => x.Set<Product>()).Returns(productDbSetMock.Object);
            productDbSetMock.Setup(x => x.Add(It.IsAny<Product>()));

            //Act
            var repository = new Repository<Product>(contextMock.Object);
            repository.Add(productMock.Object);

            //Assert
            contextMock.Verify(x => x.Set<Product>());
            productDbSetMock.Verify(x => x.Add(It.IsAny<Product>()));

        }
    }
}
