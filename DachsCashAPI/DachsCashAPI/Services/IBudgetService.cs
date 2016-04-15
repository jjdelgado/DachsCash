using System.Collections.Generic;
using DachsCashAPI.Models;

namespace DachsCashAPI.Services
{
    public interface IBudgetService
    {
        IEnumerable<BudgetModel> GetAll();
        BudgetModel Get();
    }
}
