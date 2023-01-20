using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories;
using CSharp_intro_1.Services;
using CSharp_intro_1.Services.interfaces;

namespace CSharp_intro_1.Tasks.Business.Services
{
    public class TaskBuilder
    {
        public  IRepository<TaskDto> _repo;
        public  ITaskRepository _taskRepo;
        public  IBucketService _bucketService;
        public  IPersonService _personService;
        public TaskBuilder setRepository(IRepository<TaskDto> repo)
        {
            this._repo = repo;
            return this;
        }
        public TaskBuilder setTaskRepository(ITaskRepository taskRepo)
        {
            this._taskRepo = taskRepo;
            return this;
        }
        public TaskBuilder setBucketService(IBucketService bucketService)
        {
            this._bucketService = bucketService;
            return this;
        }
        public TaskBuilder setPersonService(IPersonService personService)
        {
            this._personService = personService;
            return this;
        }
        public TaskService GetTaskService(){
            return new TaskService(this);
        }
    }
}
