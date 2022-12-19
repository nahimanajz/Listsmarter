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
Person cannot be removed if there is a task assigned to them
Bucket cannot be removed if there is a task assigned to it
Instances in each repository should properly reference instances in other repository (for example all tasks in the same bucket, should reference the same bucket in the BucketRepository)

Services should have methods to:
assign a user to task
update task status to desired value
get all tasks in a bucket with a specific status
create/update/delete user
create/update/delete task
delete bucket (only if it's empty)

- Controllers should give the possibility to call relevant service methods to:
assign a user to task
- update task status to desired value
- get all tasks in a bucket with a specific status
- create/update/delete user
- create/update/delete task
- delete bucket (only if it's empty)

Controllers and Services should operate on DTO entites, Automapper should be used in repositories to map between DTO objects and Repository models
Use dependency injection for all services and repositories.
Use LINQ for all operations that filter and retrieve data.
If anything is not clear please let me know.
**Source code for task in auto mapper**
`C:\Users\jnahimana\Desktop\coding\CSharp-intro-1\AutoMapperProfile.cs`
``` 
  CreateMap<Task, TaskDto>()
                .ForMember(dest => dest.Bucket, opt => opt.MapFrom(src => src.Bucket))
                .ForMember(dst => dst.Assignee, opt => opt.MapFrom(src => src.Assignee))
                .ForMember(dest=> dest.Description, opt => opt.MapFrom(src=> src.Description))
                .ForMember(dest=> dest.Status, opt => opt.MapFrom(src=> src.Status))
                .ReverseMap();
```

Questions
------------
- How to use dto references and still insert record
- Reading about dependency injections
- Implementing business logic