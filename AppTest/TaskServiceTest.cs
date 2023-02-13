using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using FluentAssertions;
using Moq;

namespace App.Tests
{
    public class TaskServiceTest
    {
        private readonly Mock<ITaskRepository> _itaskRepoMock = new Mock<ITaskRepository>();
        private readonly TaskService _taskService;
        private TaskDto _taskDto1;
        private  Fixture fixture;

        public TaskServiceTest()
        {
            _taskService = new TaskService(_itaskRepoMock.Object);
           fixture = new Fixture();
           
         

            _taskDto1 = fixture.Create<TaskDto>();


        }
        [Fact]
        public void GetAll_RetrieveAllTasks_ReturnListOfTasks()
        {
            //Arrange

            var taskDto = new List<TaskDto>
            {
                _taskDto1
            };

            _itaskRepoMock.Setup(repo => repo.GetAll()).Returns(taskDto);

            //Act
            var tasks = _taskService.GetAll();
            //Assert

            tasks[0].Title.Should().Be(taskDto[0].Title);
            tasks[0].Status.Should().Be(taskDto[0].Status);
        }
        [Fact]
        public void UpdateTaskStatus_GivenValidIdCurrentStatus_ReturnTaskWithNewStatus()
        {
            Guid taskId = Guid.NewGuid();
            var newStatus = (int)Status.InProgress;

            var taskDto = fixture.Create<TaskDto>();


            _itaskRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns(_taskDto1);
            _itaskRepoMock.Setup(repo => repo.UpdateByStatus(It.IsAny<Guid>(), It.IsAny<int>())).Returns(taskDto);

            var updatedTask = _taskService.UpdateByStatus(taskId, newStatus);

            updatedTask.Status.Should().Be(taskDto.Status);
            updatedTask.Id.Should().Be(taskDto.Id);

        }

        [Fact]
        public void UpdateTaskStatus_GivenInvalidTaskId_ThrowException()
        {
            Guid taskId = Guid.NewGuid();
            var newStatus = (int)Status.InProgress;

            var taskDto = fixture.Create<TaskDto>();
            _itaskRepoMock.Setup(repo => repo.GetById(It.IsAny<Guid>())).Returns((TaskDto)null);
            _itaskRepoMock.Setup(repo => repo.UpdateByStatus(It.IsAny<Guid>(), It.IsAny<int>())).Returns(taskDto);

            Action action = () => _taskService.UpdateByStatus(taskId, newStatus);
            action.Should().Throw<Exception>();

        }

        [Fact]
        public void AssignTask_GivenValidStatusAndBucketId_ReturnBucketTaskData()
        {


            var actualBucketTasks = fixture.Create<TaskDto>();

            _itaskRepoMock.Setup(repo => repo.GetByBucketAndStatus(It.IsAny<Guid>(), It.IsAny<int>())).Returns(new List<TaskDto> { actualBucketTasks });

            var bucketTasks = _taskService.GetByBucketAndStatus(actualBucketTasks.Bucket.Id, (int)Status.Open);

            1.Should().Be(bucketTasks.Count);
        }
        [Fact]
        public void AssignTask_GivenUnexistedBucketIdOrStatus_ReturnEmptyArray()
        {


            var actualBucketTasks = fixture.Create<TaskDto>();

            _itaskRepoMock.Setup(repo => repo.GetByBucketAndStatus(It.IsAny<Guid>(), It.IsAny<int>())).Returns(new List<TaskDto> { });

            var bucketTasks = _taskService.GetByBucketAndStatus(actualBucketTasks.Bucket.Id, (int)Status.Closed);

            0.Should().Be(bucketTasks.Count);

        }
    }
}
