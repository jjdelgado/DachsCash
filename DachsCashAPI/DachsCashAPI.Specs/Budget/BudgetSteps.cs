using DachsCashAPI.Controllers;
using DachsCashAPI.Database;
using DachsCashAPI.Models;
using DachsCashAPI.Services;
using TechTalk.SpecFlow;
using Xunit;

namespace DachsCashAPI.Specs.Budget
{
    [Binding]
    public class BudgetSteps
    {
        private static BudgetController _budgetController;
        public BudgetSteps()
        {
            var dbSession = new DbSession();
            var budgetService = new BudgetService(dbSession);
            _budgetController = new BudgetController(budgetService);
        }

        [Given(@"I ask for a budget with the id (.*)")]
        public void GivenIAskForABudgetWithTheId(string id)
        {
            ScenarioContext.Current["model"] = _budgetController.Get(id);
        }
        
        [Then(@"the result should be the correct budget with the correct id (.*)")]
        public void ThenTheResultShouldBeTheCorrectBudgetWithTheCorrectId(string correctId)
        {
            Assert.Equal(correctId, ((BudgetModel)ScenarioContext.Current["model"]).Id);
        }
    }
}
