using System;
using System.Collections.Generic;
using System.Web.Http;
using DachsCashAPI.Models;
using DachsCashAPI.Services;

namespace DachsCashAPI.Controllers
{
    public class BudgetController : ApiController
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        public IEnumerable<BudgetModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BudgetModel Get(int id)
        {
            return _budgetService.Get();
        }
    }
}
