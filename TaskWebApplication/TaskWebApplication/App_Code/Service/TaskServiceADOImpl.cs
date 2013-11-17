using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskWebApplication.Domain;

namespace TaskWebApplication.Service
{
    public class TaskServiceADOImpl : ServiceADOImpl, ITaskService
    {

        private readonly String TASK_TABLE_NAME = "Tasks";
        private readonly String ESTIMATE_TABLE_NAME = "Estimates";
        private readonly String KEY_COLUMN = "taskId";

        /// <summary>
        /// This method adds a task to storage.
        /// </summary>
        /// <param name="task">The task to add</param>
        /// <returns>If the task was added successfully</returns>
        public Task addTask(Task task)
        {
            if (create(TASK_TABLE_NAME, buildTaskDictionary(task)) == 1 && create(ESTIMATE_TABLE_NAME, buildEstimateDictionary(task)) == 1) {
                return task;
            }
            return null;
        }

        /// <summary>
        /// This method modifies the given task.
        /// </summary>
        /// <param name="task">The task to modify.</param>
        /// <returns>If the task was modified successfully.</returns>
        public Boolean modifyTask(Task task)
        {
            if (update(TASK_TABLE_NAME, buildTaskDictionary(task), KEY_COLUMN, task.id.ToString()) > 0 && update(ESTIMATE_TABLE_NAME, buildEstimateDictionary(task), KEY_COLUMN, task.id.ToString()) > 0)  {
                return true;
            }
            return false;            
        }
        
        /// <summary>
        /// This method finds a task given an id.
        /// </summary>
        /// <param name="id">The id to search for</param>
        /// <returns>the task associated with that id.</returns>
        public Task getTaskById(int id)
        {
            Task task = new Task();
            DataTable table = read(TASK_TABLE_NAME, KEY_COLUMN, id.ToString());
            foreach(DataRow row in table.Rows)
            {                
                 task.id = int.Parse(row["taskId"].ToString());
                 task.name = row["name"].ToString();
                 task.notes = row["notes"].ToString();
                 task.description = row["description"].ToString();
                 task.priority = int.Parse(row["priority"].ToString());
                 task.dueDate = (DateTime) row["dueDate"];
                 task.dateCreated = (DateTime) row["dateCreated"];            
            }

            DataTable estimateTable = read(ESTIMATE_TABLE_NAME, KEY_COLUMN, task.id.ToString());
            Estimate estimate = new Estimate();
            foreach(DataRow row in estimateTable.Rows) 
            {
                estimate.time = int.Parse(row["time"].ToString());
                estimate.type = row["type"].ToString();                
            }
            task.estimate = estimate;
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
            return  delete(ESTIMATE_TABLE_NAME, KEY_COLUMN, task.id.ToString()) > 0 && delete(TASK_TABLE_NAME, KEY_COLUMN, task.id.ToString()) > 0;
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

        private Dictionary<String, Object> buildTaskDictionary(Task task)
        {
            Dictionary<String, Object> columnsToValues = new Dictionary<String, Object>();
            columnsToValues.Add("taskId", task.id);
            columnsToValues.Add("name", task.name);
            columnsToValues.Add("description", task.description);
            columnsToValues.Add("notes", task.notes);
            columnsToValues.Add("priority", task.priority);
            columnsToValues.Add("dueDate", task.dueDate);
            columnsToValues.Add("dateCreated", task.dateCreated);
            return columnsToValues;
        }

        private Dictionary<String, Object> buildEstimateDictionary(Task task)
        {
            Dictionary<String, Object> columnsToValues = new Dictionary<String, Object>();
            columnsToValues.Add("time", task.estimate.time);
            columnsToValues.Add("type", task.estimate.type);
            columnsToValues.Add("taskId", task.id);
            return columnsToValues;
        }
    }
}