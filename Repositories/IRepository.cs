using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Models;

namespace CSharp_intro_1.Repositories
{
    public interface IRepository<T> 
    {
        List<T> GetAll();
        T GetById(Guid id); 
        T Create(T entity);
        T Update(T entity);
        void Delete(Guid id);
       
    }
}
