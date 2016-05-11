using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using DachsCashAPI.Models;
using DachsCashAPI.Services;
using DachsCashAPI.Utils;

namespace DachsCashAPI.Controllers
{
    [RoutePrefix("api/budget")]
    public class BudgetController : ApiController
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        /// <summary>
        /// Get all available budgets
        /// </summary>
        /// <returns>Not implemented</returns>
        [Route("")]
        [ResponseType(typeof(IEnumerable<BudgetModel>))]
        public IEnumerable<BudgetModel> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get budget by id
        /// </summary>
        /// <param name="id">Budget Id</param>
        /// <returns></returns>
        [Route("{id:int}", Name = "GetBudgetById")]
        [ResponseType(typeof(BudgetModel))]
        public BudgetModel Get(string id)
        {
            return _budgetService.Get(id);
        }
    }
}
