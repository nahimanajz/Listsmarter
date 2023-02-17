using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp_intro_1.Common.Repository.Model;
using Task = CSharp_intro_1.Repositories.Models.Task;

namespace CSharp_intro_1.People.Repositories.Modal
{
    public class Person : BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Task> Tasks { get; set; } = new();
    }
}
