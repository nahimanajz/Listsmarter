# Tasks
scope is console application and making sure all parts of project are interconnected
# Test controllers using  program.cs to see the output  by invoking the method via object of controller
# Talk about your individual task (project).
Here you have description, but I will go through it during our meeting!
Create a project based on sample code (​zip icon ArchitectureExample.zip): (you should have access, if not – let me know)
Introduce Repository Models and Repositories for:

**Person:**
Id
FirstName
LastName
**Bucket:**
Id
Title
**Task:**
Id
Title
Description
Status (enum with values: Open, InProgress, Closed)
Person (reference to Person object)

Bucket (reference to Bucket object)
Repositories should be based on in-memory Array or Collection of objects

The repositories should have basic CRUD methods:
GetAll - returns all objects
GetById - returns object with specific ID
Create - creates new instance of the object
Update - updates an object
Delete - removes an object
**Business rules:**
Person cannot be removed if there is a task assigned to them ✔
Bucket cannot be removed if there is a task assigned to it ✔
Instances in each repository should properly reference instances in other repository (for example all tasks in the same bucket, should reference the same bucket in the BucketRepository) `I don't get it`

Services should have methods to:
assign a user to task `I am using create task to assign task`
update task status to desired value ✔ [refactor needed] //suggestion using id to update it `Nb: consider updating one task with specified id`
  ✔ 
create/update/delete user ✔
create/update/delete task ✔
delete bucket (only if it's empty) ✔

- Controllers should give the possibility to call relevant service methods to:
assign a user to task


Controllers and Services should operate on DTO entites, Automapper should be used in repositories to map between DTO objects and Repository models
Use dependency injection for all services and repositories.
Use LINQ for all operations that filter and retrieve data.
If anything is not clear please let me know.


Questions
------------
- How to use dto references and still insert record
- Reading about dependency injections
- Implementing business logic

// unhandled logic
- Delete bucket, person returns message but record is not really deleted
- Person who has task assigned can be deleted ✔
same on bucket

# bugs detected
- Connecting models like bucket to task while creating new task is not done`I.E: Entity relationship `
- Baltmieh suggested from 
- suggested to close and end `if statement`
- 20 min personal call for project instructions
- Commit final changes at the end of the day[it will be great to connect task to bucket and person]
# Soluion I provided and result
- Adding `List<Task>` in `Person and Bucket model`
## Blocker
Adding new bucket or person isn't working due to adding this line in codes `List<Task> Tasks`
## Resource
https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration

Auto reload: `dotnet watch run` 

## TDD task
- Writing unit test to our project [personService, taskService and bucketService]

## database TASK

In a finishing company, there are employees described by the following characteristics: name, surname, personal identification number, date of birth.
Employees are assigned to teams. Each team has its own unique name.
One employee can only work in one team. In addition, employees work on construction sites.
One employee can work on many construction sites at the same time.

Each construction is assigned a name, start date, end date and its manager (who is also an employee).
It is important that the system contains full information about the participation of a given employee on the construction site.
It is possible that a given employee worked on a construction site for a given period of time, then left the construction site and was involved again. 

It is possible that he performed various functions in it. At a given time, an employee can perform only one function on the construction site: PAINTER, ELECTRICIAN or PLUMINATOR.
In addition, an employee performing a function on a given construction site is assigned an hourly remuneration for participation in it.

## Entity framework
**packages in App**
entityframework.sqlserver
Microsoft.EntityFrameworkCore

**Packages to put in rest api projectect**

Entity framework design 
entityframework.sqlserver

**Finally**
`dotnet ef migrations add InitialCreate --startup-project .\RestApis\RestApis.csproj --project .\App\App.csproj --output-dir Common\DataAccess\Migrations`