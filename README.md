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
Assignee (reference to Person object)

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
update task status to desired value ✔ [refactor needed] //suggestion using id to update it
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