
using AutoMapper;
using CSharp_intro_1.Models;
using CSharp_intro_1.Repositories.Models;
using Task = CSharp_intro_1.Models.Task;

namespace CSharp_intro_1.Repositories
{
    public class TaskRepository : IRepository<TaskDto>
    {
        private readonly IMapper _mapper;

        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        // TODO: HOW TO ACCES ALREADY CREATED PEOPLE TO ASSING TO A SPECIFIC TASK

        private List<Task> _tasks = new List<Task>{
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
            var mappedObject = _mapper.Map<Task>(task);
            Tasks.Add(mappedObject);



        }

        public void Update(TaskDto tsk)
        {
            Tasks.Where(task => task.Id == tsk.Id).Select(task =>
            {
                task.Title = tsk.Title == null ? task.Title : tsk.Title;
                task.Description = task.Description == null ? task.Description : tsk.Description;

                task.Status = tsk.Status == null ? task.Status : (int)tsk.Status;


                return task;
            }).ToList();
        }

        public void Delete(Guid taskId)
        {
            var deleteRecord = Tasks.RemoveAll(task => task.Id == taskId);
        }
        public void UpdateByStatus(int status, int value)
        {
            var taskByStatus = Tasks.Where(task => task.Status == status).Select(tsk =>
            {
                tsk.Status = value;
                return tsk;
            }).ToList();
           
        }



    }

}
