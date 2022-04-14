using System;

namespace Domain.Entities
{
    /// <summary>
    /// Todo item entity model.
    /// </summary>
    public class TodoItem
    {
        [Obsolete("EFCore only")]
        private TodoItem() { }

        /// <summary>
        /// Constructor for initialization todo item.
        /// </summary>
        /// <param name="name">Name of task</param>
        /// <param name="isComplete">Is task complete?</param>
        public TodoItem(string name, bool isComplete)
        {
            if (string.IsNullOrEmpty(name)) 
            { 
                throw new ArgumentNullException("Name should be specified"); 
            }
        
            Name = name;
            IsComplete = isComplete;
        }

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
