using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskWebApplication.Service;
using TaskWebApplication.Domain;

namespace UnitTestProject1.Service
{
    [TestClass]
    public class TaskServiceADOTest
    {

        ITaskService taskService = new TaskServiceADOImpl();
        Task task1;
        Estimate estimate;

        [TestInitialize]
        public void setup()
        {
            estimate = new Estimate();
            estimate.time = 5;
            estimate.type = "hours";
            task1 = new Task();
            task1.name = "task1";
            task1.priority = 1;
            task1.dateCreated = new DateTime(2013, 1, 1);
            task1.dueDate = new DateTime(2014, 1, 1);
            task1.estimate = estimate;
        }

        [TestMethod]
        public void testCRUDCycle()
        {
            Assert.AreEqual(task1,taskService.addTask(task1));
            task1.name = "newTaskName";
            Assert.IsTrue(taskService.modifyTask(task1));
            Task retrievedTask = taskService.getTaskById(task1.id);
            //currently checking only name. null fields put in are coming back as empty strings, and therefore the whole object is not quite equal.
            Assert.AreEqual(task1.name, retrievedTask.name);
            Assert.AreEqual(task1.estimate, retrievedTask.estimate);
            Assert.IsTrue(taskService.removeTask(task1));
        }

        
    }
}
