# Feeback mon, 9, 2022, Balotmiej

- In `task  model` we have `bucket id` to create connection in modals
- In `bucketmodel` & dto have list of tasks 
- Having `HttpGet("bucket/bucketId/status/{status}")` show frontend guys specifically which param to pass on endpoint ✔
- Returning created Record on `Person, bucket and Task` instead of void

what I DID: REFACTORED CODES TO ENHANCE RELATIOSHIP BETWEEN TASK, BUCKET AND PERSON ALONG WITH THEIR `Dtos`
implement single reponsibility taskservice

converted models to guid type relations in task, renaming some variables to meaningfu. ones
BLOCKER: REGISTERING NEW TASK OBJECT
NEXT TASK: IMPLEMENTING SOLID PRINCIPLES

Once a bucket is deleted then all related tasks should be removed too.[]
Baltek will be available in midday

# problem 
- While creating new bucket ID turns out to be `00000000-0000-0000-0000-000000000000`
## update bucket
- Update bucket returns  ` bucket field is required validation error` 
updating with 
``` 
{
  "id": "8d2b0328-5d0d-ac23-9b49-01ab98851109",
  "title": "Drop off",
  "tasks": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "title": "string",
      "description": "string",
      "status": 0,
      "assignee": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "bucket": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
  ]
}
 ``` 
 object returns 
- AutoMapper.AutoMapperMappingException: Missing type map configuration or unsupported mapping.


// person/
business/
        /model
        /services
repository/
 
    
n.b: controller stays at restapis folder and then change 

// What I did: Replacing conditions 
// 

Evalution feedback time estimation

- Changing folder structure  8hrs ✔
- Changing task `Person` and  `Bucket` to object 2hrs ✔
- Learning to replace if-statement in validations ✔
- and on delete record with exceptions 5hrs ✔
- Removing  controllers from `App` not in `restapis` and fixing their usage 2hrs  ✔

- Determining where to use and builder design pattern implementing  6hrs 
- Limiting number of tasks on bucket  4hrs ✔
- Forbidding to use the same name on many buckets 3hrs ✔
- Replacing repositories call from other domain with appropriate services  6hrs 
 `ex:personrep.GetById(id) in task services` Horroniecki thinks it other way ✔
- Create specific dto for updating Bucket, Task and Person

Total:
36 hours

- Remove not founds because thre is throuwn exceptions
- Renaming class names for taskAnd models interface ✔

Testing whole project

- check todos to work on Honoriecki pieces of feedback
# testing whole project
- update bucket is not working 

## Person 
- Update PERSON is not working 
- Throw exception whenever a record is not found like on bucket
## Task
 - Get all tasks 
 - Create task 
 .....
 
## asking about builder design pattern implementation
## Next task 
1. Krystian kuczkowski 
- Unit test
- Sequel
- Entity framework

- removed repetitive codes
- tested and whole project
- thrown exception for 
- updated controllers to use createModel dto instead real dtos

## Database 
`Libraries`
1. Enity framework core 
2. entity framework core sqlserver 6th version
3. Entity framework core design


**Configuring model methods**
* Data annotation 
* fluentApi
**Running migrations**
dotnet ef migrations add initialCreate --start-project .\TaskManagerAPI\TaskManagerApi.csproje 
** Task *
-updating our project with example of files krystian shared\
