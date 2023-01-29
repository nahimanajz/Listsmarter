using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using CSharp_intro_1.Models;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;
using Moq;
using Xunit.Sdk;

namespace App.Tests
{
    public class TaskCreateServiceTest
    {
        private readonly Mock<ITaskRepository> _taskRepoMock = new Mock<ITaskRepository>();
        private readonly Mock<IBucketService> _bucketService = new Mock<IBucketService>();
        private readonly Mock<IPersonService> _personService = new Mock<IPersonService>();

        private readonly TaskCreateService _taskCreateService;


        public TaskCreateServiceTest()
        {
            _taskCreateService = new TaskCreateService(_taskRepoMock.Object, _bucketService.Object, _personService.Object);
        }
        [Fact]
        public void CreateTask_GivenValidTaskData_ThenReturnCreatedTask()
        {
            // Arrange
            var taskDto = new TaskDto
            {
                Title = "Some testing TASK",
                Description = "SOME OTHER CHANGED TASK",
                Status = (int)Status.Open,
                Person = new PersonDto { FirstName = "John", LastName = "Kalisa" },
                Bucket = new BucketDto {Id= Guid.Parse("8D2B0128-5D0D-4C23-9B49-02A698852119"), Title="Example bucket"}
            };

             //TODO: this test is not working unless we comment  CheckWhetherBucketIsFull(newTask.Bucket.Id); method
            _taskRepoMock.Setup(repo => repo.CountBucketTasks(It.IsAny<Guid>())).Returns(10); 
            _taskRepoMock.Setup(repo => repo.Create(It.IsAny<TaskDto>())).Returns((taskDto));
    
            //Act
            var createdTask = _taskCreateService.Create(taskDto);
            
            //Assert
            Assert.Equal(createdTask.Title, taskDto.Title);
          

        }
        
        
    }
}
