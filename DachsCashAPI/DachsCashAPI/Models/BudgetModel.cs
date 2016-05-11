using System;

namespace DachsCashAPI.Models
{
    /// <summary>
    /// Budget Model
    /// </summary>
    public class BudgetModel
    {

        /// <summary>
        /// Budget ID - unique
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Budget given name
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