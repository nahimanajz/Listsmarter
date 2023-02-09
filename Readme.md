## Task application

## Feedback
As I am suggeste to replace `TempDb.buckets.Last()` with `newBucket`  then the output tends to retrieve with just zeroes like this
 ````
{
  "id": "00000000-0000-0000-0000-000000000000",
  "title": "How abouit new title",
  "tasks": null
}
 ````
 Whilst expected output should look like this 
 ``` 
 {
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6", // kind of valid ids
  "title": "How abouit new title",
  "tasks": null
}
 ```

 Changes were made in bucket repository on create method
```
 public BucketDto Create(BucketDto newBucket)
        {
          TempDb.buckets.Add(_mapper.Map<Bucket>(newBucket));
          return _mapper.Map<BucketDto>(TempDb.buckets.Last());
        }
```
## Solution
In Model repository ex: `BucketRepository.cs`
``` 
 public BucketDto Create(BucketDto newBucket)
        {
            TempDb.buckets.Add(_mapper.Map<Bucket>(newBucket));
            return _mapper.Map<BucketDto>(newBucket);
        }
```


**Task completed**

- Rename directories and controller variables
- Put controllers into plural to reflect pluralization changes to  api endpoints
- Remove conditional checks from `TasksController, BucketsController and
PersonsController`
- Throws exceptions in every service within `GetById` method
- Return updated record with BucketRepository,PersonRepository and
  TaskRepository without refecthing that record via `GetById method`

**Remaining tasks**

- Avoiding Circular dependency
- Alternatively creating separate service to create task or simply putting every private method below all public methods
- Using builder call `Mr. Gulis` for complete guidance on this issue

**Short notes**
 Due to an exception thrown in `GetById` method in `BucketService` and `PersonService` new task cannot be created

 **What to test**
 - Just test the methods that contains business logic
 -> testing delete person
 -> Testing delete person and delete bucket
 -> testing bucket existence method
 -

 ## Suggestion 
 creating one interface to check if bucket and person has task
 and I use this interface in `bucket` and `person` service
 this interface calls taskdto repository

 -> check if bucket exist and assign to task
 -> check whether person  exist and assign to task otherwise set that person to null

 -> creating services specific for create and update task


 # Todo:
 -> Exception should be thrown when user doesn't exist while assigning new task
 
 # 03.02.2023 todo list

 - Show Gulis implementation of Builder design pattern and ask him whether you can use it in all services or only in `BucketService`
 - Recreate database tables and show `Krystian ` using sequel 




Enity framework core 
entity framework core sqlserver 6th version
Entity framework core design