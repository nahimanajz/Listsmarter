using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Tasks.Business.Services.Interfaces
{
    public interface ITaskCreateService
    {
        TaskDto Create(TaskDto TaskDto);
    }
}
