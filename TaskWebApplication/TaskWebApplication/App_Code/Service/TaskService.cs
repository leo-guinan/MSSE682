using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Comparer;
using TaskApp.Domain;
using TaskApp.Repository;

namespace TaskApp.Service
{
    public class TaskService : ITaskService
    {

        private IRepository<Task> repository;
        private IRepository<Estimate> estimateRepository;


        public TaskService(IRepository<Task> repository, IRepository<Estimate> estimateRepository)
        {
            this.repository = repository;
            this.estimateRepository = estimateRepository;
        }

        public Boolean addTask(Task task)
        {
            Task added = repository.addEntity(task);
            return added != null;
        }

        
        public Boolean modifyTask(Task task)
        {
            return null != repository.updateEntity(task) && null != estimateRepository.updateEntity(task.Estimates.ElementAt(0));
        }

        public Task getTaskById(int id)
        {
            return repository.getEntity(id);
        }
        public List<Task> getAllTasks()
        {
            List<Task> allTasks = new List<Task>();

            foreach(Task item in repository.getAllEntities()) 
            {
                allTasks.Add(item);
            }

            return allTasks;
        }

        public Boolean removeTask(Task task)
        {
            return repository.delete(task);
        }

        public List<Task> getAllTasksByPriority()
        {
            List<Task> sortedList = getAllTasks();
            sortedList.Sort(new PriorityTaskComparer());
            return sortedList;
        }
        public List<Task> getAllTasksByDateCreated()
        {
            List<Task> sortedList = getAllTasks();
            sortedList.Sort(new DateCreatedTaskComparer());
            return sortedList;
        }
        public List<Task> getAllTasksByDueDate()
        {
            List<Task> sortedList = getAllTasks();
            sortedList.Sort(new DueDateTaskComparer());
            return sortedList;
        }

       

    }

}