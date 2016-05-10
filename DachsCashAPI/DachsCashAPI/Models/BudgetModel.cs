using System;

namespace DachsCashAPI.Models
{
    /// <summary>
    /// Budget Model
    /// </summary>
    public class BudgetModel
    {
        /// <summary>
        /// Budget given name - unique
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Budget date of creation
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Last update performed on budget
        /// </summary>
        public DateTime Updated { get; set; }
    }
}