using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Exceptions;

namespace Task3
{
    public class DefaultTaskOperationResultHandler : ITaskOperationResultHandler
    {
        public string HandleResult(Exception exception, int userId, string description)
        {
            if (exception is InvalidUserId)
                return "Invalid user ID.";
            if (exception is UserNotFoundException)
                return "User not found.";
            if (exception is TaskAlreadyExistsException taskAlreadyExists)
                return $"Task '{description}' already exists.";

            return null; // No message for no exception.
        }
    }
}
