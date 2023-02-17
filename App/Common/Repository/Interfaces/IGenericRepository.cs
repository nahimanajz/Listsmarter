using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Repository{
    public interface IGenericRepository<TEntity, Tdto> where Tdto: class where TEntity:class
{
        List<Tdto> GetAll();
        Tdto GetById(Guid id);
        Tdto Create(Tdto entity);
        Tdto Update(Tdto entity);
        void Delete(Guid id);
    }
}
