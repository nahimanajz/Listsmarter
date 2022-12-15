using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Repositories
{
    interface IRepository<T> 
    {
        List<T> GetAll();
        T GetById(int id); 
        T Create(T entity);
        T Update(T entity);
        T Delete(int entity);
    }
}
