using System;
using System.Collections.Generic;
using DachsCashAPI.Database;
using DachsCashAPI.Models;

namespace DachsCashAPI.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IDbSession _dbSession;

        public BudgetService(IDbSession dbSession)
        {
            _dbSession = dbSession;
        }

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