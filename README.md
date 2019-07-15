# AireSpringTest

This solution has been created following a multi-layered Repository pattern.

Three projects have been created:

- Core: Contains domain classes and the interface with the operations that can be performed to the tables.

- Infrastructure: Contains the implementation of the database operations interface and creates a database using EntityFramework aggregating the tables and creating stored procedures for CRUD operations. The database can be checked in the App_Data directory of the Web project (AireSpringTest.Web).

- Web: It is a WebForms project that includes the web page that performs the CRUD operations (Employees.aspx) on the created table. 

The CRUD functions are completely included, as well as the functionality to search by LastName and Phone. The instructions for the masks and output formats have also been followed.
