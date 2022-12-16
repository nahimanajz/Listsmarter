
using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Models.Task;

namespace CSharp_intro_1.Repositories
{
    public class TaskRepository: IRepository<TaskDto>
    {
        private readonly IMapper _mapper;

        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        private List<Task> _tasks = new List<Task>
        {
            new Task
            {
                Title = "Wake up",
                Description = "Remove bed cover",
                Status = 0,
                Assignee = new Person{Id =1, FirstName="Janvier", LastName="Nah.."},
                Bucket =  new Bucket{Id =1, Title="Doing something new"}

            },
            new Task
           {
                Title = "Brush my teeth ",
                Description = "Put toothpaste on my tooth brush",
                Status = 1,
                Assignee = new Person{Id =1, FirstName="Hugues", LastName="Ntwali.."},
                Bucket =  new Bucket{Id =1, Title="Doing something new"}

            },
             new Task
            {
                Title = "Some give task",
                Description = "Put toothpaste on my tooth brush",
                Status = 2,
                Assignee = new Person{Id =1, FirstName="Dom..", LastName="Ndah.."},
                Bucket =  new Bucket{Id =1, Title="Doing something new"}

            }
        };
        
        public List<TaskDto> GetAll()
        {
            return _mapper.Map<List<TaskDto>>(_tasks.ToList());
            
        }

        public TaskDto GetById(int id)
        {
         
            return _mapper.Map<TaskDto>(_tasks.FirstOrDefault(task => task.Id == id, null)); ;

        }

        public void Create(TaskDto task)
        {
            var newtask = new Task
            {
                Id = _tasks.Count + 1,
                Title = task.Title,
                Description = task.Description,
                Status = 1,
                Assignee = new Person { Id = 1, FirstName = "Janvier", LastName = "Nah.." },
               Bucket = new Bucket { Id = 1, Title = "Doing something new" }
            };
            _tasks.Add(newtask);
      
        }

        public void Update(TaskDto task)
        {
            _tasks.Where(task => task.Id == task.Id).Select(task =>
            {
                task.Title = task.Title == null ? task.Title : task.Title;
                task.Description = task.Description == null ? task.Description : task.Description;
                task.Assignee = task.Assignee == null ? task.Assignee : task.Assignee;
                task.Status = task.Status == null ? task.Status : task.Status;
                task.Bucket = task.Bucket == null ? task.Bucket : task.Bucket;
          
                return task;
            }).ToList();
        }

        public void Delete(int taskId)
        {
            var deleteRecord = _tasks.RemoveAll(task => task.Id == taskId);
        }


    }
  
}
