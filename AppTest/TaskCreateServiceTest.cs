using AutoFixture;
using CSharp_intro_1.Models;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services;
using FluentAssertions;
using Moq;

namespace App.Tests
{
    public class TaskCreateServiceTest
    {
        private readonly Mock<ITaskRepository> _taskRepoMock = new Mock<ITaskRepository>();
        private readonly Mock<IBucketService> _bucketService = new Mock<IBucketService>();
        private readonly Mock<IPersonService> _personService = new Mock<IPersonService>();

        private readonly TaskCreateService _taskCreateService;
        private Fixture fixture = new Fixture();

        public TaskCreateServiceTest()
        {
            _taskCreateService = new TaskCreateService(_taskRepoMock.Object, _bucketService.Object, _personService.Object);
        }
        [Fact]
        public void Create_GivenValidTaskData_ReturnCreatedTask()
        {
            // Arrange
            var taskDto = fixture.Create<TaskDto>();

            _taskRepoMock.Setup(repo => repo.CountBucketTasks(It.IsAny<Guid>())).Returns(10);
            _taskRepoMock.Setup(repo => repo.Create(It.IsAny<TaskDto>())).Returns((taskDto));

            //Act
            var createdTask = _taskCreateService.Create(taskDto);

            //Assert
            createdTask.Title.Should().Be(taskDto.Title);



        }



    }
}
