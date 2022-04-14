using System;

namespace Domain.Entities
{
    /// <summary>
    /// TodoItem entity model.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is task complete?
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Secret key for task.
        /// </summary>
        public string Secret { get; set; }
    }
}
