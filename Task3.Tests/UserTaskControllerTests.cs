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
            _controller = new UserTaskController(taskService);
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

            Assert.Throws<InvalidUserId>(() => _controller.AddTaskForUser(userId, description, model));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_NonExistentUser_ReturnsNullAndUserNotFoundMessage()
        {
            var model = new ResponseModelStub();
            string description = "task4";
            int userId = 2, existingUserId = 1;

            Assert.Throws<UserNotFoundException>(() => _controller.AddTaskForUser(userId, description, model));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }

        [Test]
        public void CreateUserTask_NonExistentUser_TaskAlreadyExistsMessage()
        {
            var model = new ResponseModelStub();
            string description = "task3";
            int userId = 1, existingUserId = 1;

            Assert.Throws<TaskAlreadyExistsException>(() => _controller.AddTaskForUser(userId, description, model));
            Assert.That(_userDao.GetUser(existingUserId).Tasks.Count, Is.EqualTo(3));
        }
    }
}