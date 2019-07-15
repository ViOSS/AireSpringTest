# AireSpringTest

This solution has been created following a multi-layered Repository pattern.

Three projects have been created:

- Core: Contains domain classes and the interface with the operations that can be performed to the tables.

- Infrastructure: Contains the implementation of the database operations interface and creates a database using EntityFramework aggregating the tables and creating stored procedures for CRUD operations. The database can be checked in the AppData directory of the Web project (it is not included in the repository, so it will be out of the project).

- Web: It is a WebForms project that includes the web page that performs the CRUD operations (Employees.aspx) on the created table. Once the project has been executed you can check the database in the AppData folder (the database is not included in the project).

The CRUD functions are completely included, as well as the functionality to search by LastName and Phone. The instructions for the masks and output formats have also been followed.
