using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;
using Moq;

namespace App.Tests
{
    public class TaskServiceTest
    {
        private readonly Mock<IRepository<TaskDto>> _taskRepoMock;
        private readonly Mock<ITaskRepository> _ItaskRepoMock;
        private readonly IBucketService _bucketService;
        private readonly IPersonService _personService;
        private readonly TaskService _taskService;

        public TaskServiceTest()
        {
            _taskService = new TaskService(_taskRepoMock.Object, _ItaskRepoMock.Object, _bucketService, _personService);

        }
        public void AllTask_GetAllTasks_ReturnListOfTasks()
        {
            _taskRepoMock = new Mock<IRepository<TaskDto>>();
        }
    }
}
