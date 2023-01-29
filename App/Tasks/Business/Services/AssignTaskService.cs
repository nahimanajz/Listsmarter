using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Services.interfaces;
using CSharp_intro_1.Tasks.Business.Services.Interfaces;

namespace CSharp_intro_1.Tasks.Business.Services
{
    public class AssignTaskService : IAssignTaskService
    {
        private readonly ITaskRepository _repo;
        private readonly ITaskService _taskService;
        private readonly IPersonService _personService;

        public AssignTaskService(ITaskRepository repo, IPersonService personService, ITaskService taskService)
        {
            _repo= repo;
            _taskService = taskService;
            _personService = personService;
            
        }

        public List<TaskDto> AssignTask(Guid taskId, Guid personId)
        {
            _taskService.GetById(taskId);
            _personService.GetById(personId);
            return _repo.AssignTask(taskId, personId);
        }
    }
}
