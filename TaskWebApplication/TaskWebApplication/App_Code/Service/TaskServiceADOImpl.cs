using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskWebApplication.Service
{
    public class TaskServiceADOImpl : ServiceADOImpl, ITaskService
    {

        private sealed String TABLE_NAME = "Tasks";

        /// <summary>
        /// This method adds a task to storage.
        /// </summary>
        /// <param name="task">The task to add</param>
        /// <returns>If the task was added successfully</returns>
        public Task addTask(Task task)
        {
            return null;
        }

        /// <summary>
        /// This method modifies the given task.
        /// </summary>
        /// <param name="task">The task to modify.</param>
        /// <returns>If the task was modified successfully.</returns>
        public Boolean modifyTask(Task task)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        /// <summary>
        /// This method finds a task given an id.
        /// </summary>
        /// <param name="id">The id to search for</param>
        /// <returns>the task associated with that id.</returns>
        public Task getTaskById(int id)
        {
            Task task = new Task();
            SqlDataReader reader = read(id, TABLE_NAME);
            while (reader.Read())
            {
                task.id = reader.GetInt32(reader.GetOrdinal("id"));
                task.name = reader.GetString(reader.GetOrdinal("name"));
            }
            return task;
        }

        /// <summary>
        /// This method gets all stored tasks.
        /// </summary>
        /// <returns>a collection of all the tasks</returns>
        public List<Task> getAllTasks()
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        /// <summary>
        /// This method removes a task from storage.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public Boolean removeTask(Task task)
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        /// <summary>
        /// This method gets all stored tasks, and sorts them by priority.
        /// </summary>
        /// <returns>the collection of tasks sorted by priority.</returns>
        public List<Task> getAllTasksByPriority()
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        /// <summary>
        /// This method gets all stored tasks, and sorts them by dateCreated.
        /// </summary>
        /// <returns>the collection of tasks sorted by dateCreated</returns>
        public List<Task> getAllTasksByDateCreated()
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        /// <summary>
        /// This method gets all stored tasks, and sorts them by dueDate.
        /// </summary>
        /// <returns>the collection of tasks sorted by dueDate</returns>
        public List<Task> getAllTasksByDueDate()
        {
            throw new NotImplementedException("Not implemented yet.");
        }

        private Boolean addTask(SqlConnection conn, Object[] task)
        {
            return true;
        }
    }
}