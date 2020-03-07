using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Context.Domain.Tests
{
    public class UnitOfWorkTest
    {
        [Test]
        public void UnitOfWork_Call_SaveChanges()
        {
            var mockContext = new Mock<DbContext>();
            var unitOfWork = new UnitOfWork<DbContext>(mockContext.Object);
            unitOfWork.SaveChanges();
            mockContext.Verify(x => x.SaveChanges());
        }
    }
}
