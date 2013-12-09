using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskWebApplication.Domain;
namespace TaskApp.Business
{
    /// <summary>
    /// This is a business manager. It controls the business logic for all task related functionality. Adding, modification, removing, getting all, etc.
    /// </summary>
    public interface ITaskManager
    {
        /// <summary>
        /// This method adds a task.
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="notes">Any notes about the task.</param>
        /// <param name="description">A brief description of the task.</param>
        /// <param name="dateCreated">The date the task was created.</param>
        /// <param name="dueDate">The date this task is due to be completed.</param>
        /// <param name="priority">The priority of the task.</param>
        /// <param name="estimateTime">How long the task should take.</param>
        /// <param name="estimateType">The unit of the task estimate.</param>
        /// <returns>if the task was added correctly.</returns>
        Boolean addTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType);

        /// <summary>
        /// This method modifies a task.
        /// </summary>
        /// <param name="name">The name of the task.</param>
        /// <param name="notes">Any notes about the task.</param>
        /// <param name="description">A brief description of the task.</param>
        /// <param name="dateCreated">The date the task was created.</param>
        /// <param name="dueDate">The date this task is due to be completed.</param>
        /// <param name="priority">The priority of the task.</param>
        /// <param name="estimateTime">How long the task should take.</param>
        /// <param name="estimateType">The unit of the task estimate.</param>
        /// <returns>if the task was modified correctly.</returns>
         Boolean modifyTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType, int taskId);
        
        /// <summary>
        /// This method gets all the currently available tasks.
        /// </summary>
        /// <returns>A collection of tasks.</returns>
         List<Task> getAllTasks();

        /// <summary>
        /// This method gets all tasks, sorted by a given field.
        /// </summary>
        /// <param name="by">The field to sort on</param>
        /// <returns>the sorted collection of tasks</returns>
         List<Task> getAllTasks(String by);

        /// <summary>
        /// Delete a task with the given ID.
        /// </summary>
        /// <param name="taskId"></param>
         void DeleteTask(int taskId);

    }
}
