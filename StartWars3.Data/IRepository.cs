namespace StarWars3.Data
{
    using System;
    using System.Linq;

    public interface IRepository<T>  where T : class
    {
        IQueryable<T> All();

        T GetById(int? id);

        T FirstOrDefault(Func<T, bool> predicate);

        bool Any(Func<T, bool> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);
    }
}
