using System;
using DachsCashAPI.Controllers;
using DachsCashAPI.Services;
using Moq;
using Xunit;

namespace DachsCashAPI.Tests.Controllers.BudgetControllers
{
    public class BudgetController_GetAll_Tests
    {
        [Fact]
        public void Should_Return_NotImplementedException()
        {
            var service = new Mock<IBudgetService>().Object;
            var budgetController = new BudgetController(service);

            Assert.Throws<NotImplementedException>(() => budgetController.GetAll());
        }
    }
}
