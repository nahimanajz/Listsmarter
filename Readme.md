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
