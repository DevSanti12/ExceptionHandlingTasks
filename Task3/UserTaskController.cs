using System;
using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;
        private readonly ITaskOperationResultHandler _resultHandler;

        public UserTaskController(UserTaskService taskService, ITaskOperationResultHandler resultHandler)
        {
            _taskService = taskService;
            _resultHandler = resultHandler;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                // Delegate task addition to the service
                _taskService.AddTaskForUser(userId, new UserTask(description));
                return true;
            }
            catch (Exception ex)
            {
                // Delegate exception handling to the result handler
                string message = _resultHandler.HandleResult(ex, userId, description);
                model.AddAttribute("action_result", message);
                return false;
            }
        }
    }
}