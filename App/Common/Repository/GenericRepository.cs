using AutoMapper;
using CSharp_intro_1.Common.Business.Models.Abstractions;
using CSharp_intro_1.Common.Repository.DataAccess;
using CSharp_intro_1.Common.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace CSharp_intro_1.Common.Repository
{
    public class GenericRepository<TEntity, Tdto> : IGenericRepository<TEntity, Tdto>
        where Tdto : class, IIdentityDto
        where TEntity : BaseModel
    {
        private AppContexts _contexts;
        private DbSet<TEntity> Table = null;
        private readonly IMapper _mapper;

        public GenericRepository(AppContexts contexts, IMapper mapper)
        {
            _contexts = contexts;
            Table = _contexts.Set<TEntity>();
            _mapper = mapper;
        }
        public List<Tdto> GetAll()
        {
            return _mapper.Map<List<Tdto>>(Table.ToList());

        }

        public Tdto Create(Tdto entity)
        {
            var newRecord = _mapper.Map<TEntity>(entity);
            Table.Add(newRecord);

            _contexts.SaveChanges();

            return _mapper.Map<Tdto>(newRecord);


        }

        public void Delete(Guid id)
        {
            var currentData = Table.Find(id);
            Table.Remove(currentData);
            _contexts.SaveChanges();


        }

        public Tdto GetById(Guid id)
        {
            return _mapper.Map<Tdto>(Table.Find(id));
        }

        public Tdto Update(Tdto entity)
        {
            var updatedRecord = Table.First(x => entity.Id == x.Id);

            _mapper.Map(entity, updatedRecord);
            _contexts.SaveChanges();

            return _mapper.Map<Tdto>(updatedRecord);

        }
    }
}
