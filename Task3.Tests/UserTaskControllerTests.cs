using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Task3.DoNotChange;
using Task3.Tests.Stubs;
using Task3.Exceptions;

namespace Task3.Tests
{
    [TestFixture]
    public class UserTaskControllerTests
    {
        private readonly UserTaskController _controller;
        private readonly IUserDao _userDao;

        public UserTaskControllerTests()
        {
            _userDao = new UserDaoStub();
            var taskService = new UserTaskService(_userDao);
            var resultHandler = new DefaultTaskOperationResultHandler(); // Add the result handler!
            _controller = new UserTaskController(taskService, resultHandler);
        }

        [Test]
        public void CreateUserTask_ValidData_ReturnsTaskAndEmptyMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(model.GetActionResult(), Is.Null);
            Assert.That(_userDao.GetUser(userId).Tasks.Count, Is.EqualTo(4));
            StringAssert.AreEqualIgnoringCase(_userDao.GetUser(userId).Tasks[3].Description, description);
        }

        [Test]
        public void CreateUserTask_InvalidUserId_ReturnsNullAndInvalidUserIdMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = -11, existingUserId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            Assert.That(model.GetActionResult(), Is.EqualTo("Invalid user ID."));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_NonExistentUser_ReturnsNullAndUserNotFoundMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 2, existingUserId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            Assert.That(model.GetActionResult(), Is.EqualTo("User not found."));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_NonExistentUser_TaskAlreadyExistsMessage()
        {
            var model = new ResponseModelStub();
            string description = "task3";
            int userId = 1, existingUserId = 1;

            bool result = _controller.AddTaskForUser(userId, description, model);

            Assert.That(result, Is.EqualTo(false));
            Assert.That(model.GetActionResult(), Is.EqualTo("Task 'task3' already exists."));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }
    }
}