using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using Moq;

namespace App.Tests
{
    public class TaskServiceTest
    {
        private readonly Mock<ITaskRepository> _itaskRepoMock = new Mock<ITaskRepository>();
        private readonly TaskService _taskService;
        private TaskDto _taskDto1;
        
        public TaskServiceTest()
        {
            _taskService = new TaskService(_itaskRepoMock.Object);
            _taskDto1 = new TaskDto
            {
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = (int)Status.Open,
                Person = new PersonDto { FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };

        }
        [Fact]
        public void GetAll_RetrieveAllTasks_ReturnListOfTasks()
        {
            //Arrange

            var taskDto = new List<TaskDto> {
            _taskDto1
            };

            _itaskRepoMock.Setup(repo => repo.GetAll()).Returns(taskDto);

            //Act
            var tasks = _taskService.GetAll();
            //Assert
            Assert.Equal(tasks[0].Title, taskDto[0].Title);
            Assert.Equal(0, (int)taskDto[0].Status);
        }
        [Fact]
        public void UpdateTaskStatus_GivenValidIdCurrentStatus_ReturnTaskWithNewStatus()
        {
            Guid taskId = Guid.NewGuid();
            var oldStatus = (int) Status.Open;
            var newStatus = (int) Status.InProgress;

            var taskDto = new TaskDto
            {
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = Status.InProgress,
                Person = new PersonDto { FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };


            _itaskRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(_taskDto1);
            _itaskRepoMock.Setup(repo => repo.UpdateByStatus(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<TaskDto>{ taskDto });

            var updatedTask = _taskService.UpdateByStatus(taskId, oldStatus, newStatus);
            
            Assert.Equal(updatedTask[0].Status, taskDto.Status);
            Assert.Equal(updatedTask[0].Id, taskDto.Id);

        }

        [Fact]
        public void UpdateTaskStatus_GivenInvalidTaskId_ThrowException()
        {
            Guid taskId = Guid.NewGuid();
            var oldStatus = (int)Status.Open;
            var newStatus = (int)Status.InProgress;
            

            var taskDto = new TaskDto
            {
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = Status.InProgress,
                Person = new PersonDto { FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };


            _itaskRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((TaskDto)null);
            _itaskRepoMock.Setup(repo => repo.UpdateByStatus(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<TaskDto> { taskDto });

            Assert.Throws<Exception>(() => _taskService.UpdateByStatus(taskId, oldStatus, newStatus));

        }

        [Fact]
        public void AssignTask_GivenValidStatusAndBucketId_ReturnBucketTaskData()
        {


            var actualBucketTasks = new TaskDto
            {
                Id = Guid.NewGuid(),
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = Status.Open,
                Person = new PersonDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698752111"), FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };

            _itaskRepoMock.Setup(repo => repo.GetByBucketAndStatus(It.IsAny<Guid>(), It.IsAny<int>())).Returns(new List<TaskDto> { actualBucketTasks });

            var bucketTasks = _taskService.GetByBucketAndStatus(actualBucketTasks.Bucket.Id, (int)Status.Open);
                
            Assert.Equal(1, bucketTasks.Count);

        }
        [Fact]
        public void AssignTask_GivenUnexistedBucketIdOrStatus_ReturnEmptyArray()
        {


            var actualBucketTasks = new TaskDto
            {
                Id = Guid.NewGuid(),
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = Status.Open,
                Person = new PersonDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698752111"), FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto { Id = Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title = "Example bucket" }
            };

            _itaskRepoMock.Setup(repo => repo.GetByBucketAndStatus(It.IsAny<Guid>(), It.IsAny<int>())).Returns(new List<TaskDto> {  });

            var bucketTasks = _taskService.GetByBucketAndStatus(actualBucketTasks.Bucket.Id, (int)Status.Closed);

            Assert.Equal(0, bucketTasks.Count);

        }
    }
}
