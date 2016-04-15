using System;
using System.Collections.Generic;
using DachsCashAPI.Models;

namespace DachsCashAPI.Services
{
    public class BudgetService : IBudgetService
    {
        public IEnumerable<BudgetModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public BudgetModel Get()
        {
            return new BudgetModel
            {
                Name = "Budget from Service",
                Created = DateTime.Now,
                Updated = DateTime.Now
            };
        }
    }
}