Task 1: 
Open Program class under Task1 project and implement a method that prints the first character of each entered input line. Use exception handling mechanism to validate input for empty string.  

Task 2: 
Open NumberParser class under Task2 project and implement Parse method to convert a string value to integer. 
It is NOT allowed to use int.Parse(), int.TryParse() or any other built-in conversion methods. 
Error handling should be implemented. All unit tests should pass successfully. 


Task 3 (Optional): 
Open UserTaskController and UserTaskService classes under Task3 project and change code-based error handling to exception-based one. If you notice any violations of open/close principle, fix them. 
No changes in the code under DoNotChange folder are expected. All unit tests should pass successfully. 

Changes of OCP:

Introduced the ITaskOperationResultHandler interface:
Provides an abstraction for processing task operation results, handling exceptions, and creating user-friendly feedback messages.

Implemented DefaultTaskOperationResultHandler:
Maps exceptions (e.g., InvalidUserId, UserNotFoundException, TaskAlreadyExistsException) to meaningful messages.

Updated UserTaskController to delegate result handling to ITaskOperationResultHandler, ensuring extensibility and flexibility.
Dependency Injection:

UserTaskController now accepts an instance of ITaskOperationResultHandler, enabling easy replacement or customization of result-handling strategies.
