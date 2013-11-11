using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskWebApplication.Service;
using TaskApp.Domain;

namespace UnitTestProject1.Service
{
    [TestClass]
    public class TaskServiceADOTest
    {

        ITaskService taskService = new TaskServiceADOImpl();

        [TestMethod]
        public void testPreliminaryConnection()
        {
            taskService.addTask(null);
        }

        [TestMethod]
        public void testGetTaskById()
        {
            Task task = taskService.getTaskById(1);
            Assert.AreEqual(1, task.id);
            Assert.AreEqual("testName", task.name);


        }
    }
}
