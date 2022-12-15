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
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
