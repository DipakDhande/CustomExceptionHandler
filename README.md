# CustomExceptionHandler
This solution contains two projects, CustomExceptionHandler and CustomExceptionHandlerTester
Main moto is to create CustomExceptionHandler to write logs when exception occurs.
CustomExceptionHandler is a class bibrary project which writes loggs when exception occurs.
CustomExceptionHandler be reffered and used in any other project.
CustomExceptionHandler can write logs to different types of targets like text file, SQL server, on clouds etc.
The targes are fully configurable in the appsettings.json file in the parent project.
No need to update code base to update/remove an existing target or add a new target, they can be added/updated/removed from the appsettings.json file itself.
One parent project is also added to the solution for testing purpose, this parent project is using the cutom exception handler class library to write logs to text file.
