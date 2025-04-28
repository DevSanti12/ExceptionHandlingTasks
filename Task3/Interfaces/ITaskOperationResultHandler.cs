using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3;

public interface ITaskOperationResultHandler
{
    string HandleResult(Exception exception, int userId, string description);
}


