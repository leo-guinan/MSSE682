using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskWebApplication.Factory.Service;
using TaskWebApplication.Service;

namespace TaskApp.Business
{
    public class TaskManager : ITaskManager
    {
        private IUserService userService;
        private ITaskService taskService;

        private IServiceFactory serviceFactory;

        public TaskManager(IServiceFactory serviceFactory)
        {
            this.serviceFactory = serviceFactory;
            taskService = (ITaskService) serviceFactory.getService("taskService");
        }

        public IList<Task> getAllTasks()
        {
            return taskService.getAllTasks();
        }

        public IList<Task> getAllTasks(String by)
        {
            IList<Task> tasks;
            switch(by) 
            {
                case "priority":
                    tasks = taskService.getAllTasksByPriority();
                    break;
                case "dueDate":
                    tasks = taskService.getAllTasksByDueDate();
                    break;
                case "dateCreated":
                    tasks = taskService.getAllTasksByDateCreated();
                    break;
                default:
                    tasks = taskService.getAllTasks();
                    break;
            }
            return tasks;
        }

        public Boolean addTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType)
        {
            Task task = new Task();
            task.name = name;
            task.notes = notes;
            task.priority = priority;
            task.description = description;
            task.dateCreated = dateCreated;
            task.dueDate = dueDate;
            Estimate estimate = new Estimate();
            //estimate.Task = task;
            estimate.time = estimateTime;
            estimate.type = estimateType;
            //task.Estimates.Add(estimate);
            return taskService.addTask(task);
        }

        public Boolean modifyTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType, int taskId)
        {
            Task task = taskService.getTaskById(taskId);
            if (null != name)
            {
                task.name = name;
            }
            if (null != notes)
            {
                task.notes = notes;
            }
            if (null != description)
            {
                task.description = description;
            }
            if (null != dateCreated)
            {
                task.dateCreated = dateCreated;
            }
            if (null != dueDate)
            {
                task.dueDate = dueDate;
            }
            if (-1 != priority)
            {
                task.priority = priority;
            }
            //,Estimate estimate = task.Estimates.ElementAt(0);
            
            /*if (estimate != null)
            {
                if (estimateTime != -1)
                {
                    estimate.time = estimateTime;
                }

                if (estimateType != null)
                {
                    estimate.type = estimateType;
                }
            }*/
            return taskService.modifyTask(task);

        }




    }
}