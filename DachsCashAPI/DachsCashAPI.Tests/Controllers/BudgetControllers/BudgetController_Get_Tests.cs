using DachsCashAPI.Controllers;
using DachsCashAPI.Database;
using DachsCashAPI.Services;
using Moq;
using Xunit;

namespace DachsCashAPI.Tests.Controllers.BudgetControllers
{
    public class BudgetController_Get_Tests
    {

        private readonly IBudgetService _budgetService;

        public BudgetController_Get_Tests()
        {
            var dbSession = new Mock<IDbSession>().Object;
            _budgetService = new BudgetService(dbSession);    
        }
        [Theory]
        [InlineData("test", "test")]
        [InlineData("42", "42")]
        public void Should_Return_Correct_BudgetModel(string id, string expectedId)
        {
            var budgetController = new BudgetController(_budgetService);
            Assert.Equal(expectedId, budgetController.Get(id).Id);
        }
    }
}
