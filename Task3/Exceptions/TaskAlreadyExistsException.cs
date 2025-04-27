using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Exceptions
{
    public class TaskAlreadyExistsException : Exception
    {
        public TaskAlreadyExistsException(string task)
        {
            Console.WriteLine("Task {0} already exists!", task);
        }
    }
}
