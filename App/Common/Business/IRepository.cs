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
