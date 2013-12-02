using SharedLibraries.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWebApplication.Domain;

namespace TaskWebApplication.Service
{
    /// <summary>
    /// This is a service for supporting the Task Objects. It deals with adding, modifying, and removing tasks, as well 
    /// as getting tasks from storage and returning sorted lists.
    /// </summary>
    public interface ITaskService : IService
    {
        /// <summary>
        /// This method adds a task to storage.
        /// </summary>
        /// <param name="task">The task to add</param>
        /// <returns>If the task was added successfully</returns>
        Task addTask(Task task);

        /// <summary>
        /// This method modifies the given task.
        /// </summary>
        /// <param name="task">The task to modify.</param>
        /// <returns>If the task was modified successfully.</returns>
        Boolean modifyTask(Task task);

        /// <summary>
        /// This method finds a task given an id.
        /// </summary>
        /// <param name="id">The id to search for</param>
        /// <returns>the task associated with that id.</returns>
        Task getTaskById(int id);

        /// <summary>
        /// This method gets all stored tasks.
        /// </summary>
        /// <returns>a collection of all the tasks</returns>
        List<Task> getAllTasks();

        /// <summary>
        /// This method removes a task from storage.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Boolean removeTask(Task task);

        /// <summary>
        /// This method gets all stored tasks, and sorts them by priority.
        /// </summary>
        /// <returns>the collection of tasks sorted by priority.</returns>
        List<Task> getAllTasksByPriority();

        /// <summary>
        /// This method gets all stored tasks, and sorts them by dateCreated.
        /// </summary>
        /// <returns>the collection of tasks sorted by dateCreated</returns>
        List<Task> getAllTasksByDateCreated();

        /// <summary>
        /// This method gets all stored tasks, and sorts them by dueDate.
        /// </summary>
        /// <returns>the collection of tasks sorted by dueDate</returns>
        List<Task> getAllTasksByDueDate();
    }
}