
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
 // TODO: HOW TO ACCES ALREADY CREATED PEOPLE TO ASSING TO A SPECIFIC TASK
       // private Bucket _buckets =
        private List<Task> _tasks = new List<Task>
        {
            new Task
            {
                Id= Guid.Parse("9D2B0228-5D0D-4C23-8B49-01A698851109"),
                Title = "Wake up",
                Description = "Remove bed cover",
                Status = (int) StatusEnum.Open,
                Assignee = new Person{Id =Guid.NewGuid(), FirstName="George", LastName="Nah.."},
                Bucket =  new Bucket{Id =Guid.NewGuid(), Title="Doing something new"}

            },
            new Task
           {
                Id= Guid.Parse("4D2B0228-5D0D-4C23-8B49-01A698851104"),

                Title = "Brush my teeth ",
                Description = "Put toothpaste on my tooth brush",
                Status = (int) StatusEnum.Closed,
                Assignee = new Person{Id =Guid.NewGuid(), FirstName="John", LastName="Doe.."},
                Bucket =  new Bucket{Id =Guid.NewGuid(), Title="Doing something new"}

            },
             new Task
            {
                Id= Guid.Parse("8D2B0228-5D0D-4C23-9B49-01A698851109"),

                Title = "Some given task",
                Description = "Put toothpaste on my tooth brush",
                Status = (int) StatusEnum.InProgress,
                Assignee = new Person{Id =Guid.NewGuid(), FirstName="Dom..", LastName="Ndah.."},
                Bucket =  new Bucket{Id =Guid.NewGuid(), Title="Doing something new"}

            }
        };

        public List<Task> Tasks { get => _tasks; set => _tasks = value; }

        public List<TaskDto> GetAll()
        {
            return _mapper.Map<List<TaskDto>>(Tasks.ToList());
            
        }

        public TaskDto GetById(Guid id)
        {
         
            return _mapper.Map<TaskDto>(Tasks.FirstOrDefault(task => task.Id == id, null)); ;

        }

        public void Create(TaskDto task)
        {
            
            Console.WriteLine(task.Assignee);
           
           // Tasks.Add(task);
            
        }

        public void Update(TaskDto task)
        {
            Tasks.Where(task => task.Id == task.Id).Select(task =>
            {
                task.Title = task.Title == null ? task.Title : task.Title;
                task.Description = task.Description == null ? task.Description : task.Description;
                task.Assignee = task.Assignee == null ? task.Assignee : task.Assignee;
                task.Status = task.Status == null ? task.Status : task.Status;
                task.Bucket = task.Bucket == null ? task.Bucket : task.Bucket;
          
                return task;
            }).ToList();
        }

        public void Delete(Guid taskId)
        {
            var deleteRecord = Tasks.RemoveAll(task => task.Id == taskId);
        }


    }
  
}
